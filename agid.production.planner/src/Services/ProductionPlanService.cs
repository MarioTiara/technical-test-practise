using System.Collections;
using Production.Planner.Data;
using Production.Planner.Models;

namespace Production.Planner.Services;


public interface IProductionPlanService
{
    IEnumerable<int> RedistributedProductionShedule { get; }
    IEnumerable<int> PlannedProductionShedule { get; }
    void Add( int thaun,int minggu, int[] rencanaProduksiHarian);
    Task SaveRencanaProduksiHarianAsync();
}
public class ProductionPlanService : IProductionPlanService
{
    private int _mingguKe;
    private int _tahun;
    private int[] _rencanaProduksiHarian;
    private int[] _distribusiProduksiHarian;
    private readonly IRepository<ProductionScheduleModel> _repository;
    public IEnumerable<int> RedistributedProductionShedule => _distribusiProduksiHarian.AsReadOnly();

    public IEnumerable<int> PlannedProductionShedule => _rencanaProduksiHarian.AsReadOnly();

    public ProductionPlanService(IRepository<ProductionScheduleModel> repository)
    {
      _mingguKe=0;
      _tahun=0;
      _rencanaProduksiHarian=new int[7];
      _distribusiProduksiHarian=new int[7];
      _repository = repository;
    }

    public void Add( int tahun,int minggu, int[] rencanaProduksiHarian)
    {
        _mingguKe = minggu;
        _tahun = tahun;
        if (rencanaProduksiHarian.Count() > 7)
        {
            throw new ArgumentException("rencana produksi harian tidak boleh lebih dari 7 hari");
        }

        _rencanaProduksiHarian = rencanaProduksiHarian;
        _distribusiProduksiHarian = this.RedistributeProduction(rencanaProduksiHarian);
    }
    public async Task SaveRencanaProduksiHarianAsync()
    {
        var plannedSchedule = CreatePlannedSchedule();
        try
        {
            await _repository.AddRangeAsync(plannedSchedule);

        }
        catch (Exception)
        {
            throw;
        }
    }

    private List<ProductionScheduleModel> CreatePlannedSchedule()
    {
        var schedule = new List<ProductionScheduleModel>();
        int totalDays = _rencanaProduksiHarian.Length;
        for (int i = 0; i < totalDays; i++)
        {
            schedule.Add(new ProductionScheduleModel(_tahun, _mingguKe, (Days)i + 1, this._rencanaProduksiHarian[i], this._distribusiProduksiHarian[i]));
        }
        return schedule;
    }

    private int[] RedistributeProduction(int[] schedule)
    {
        int numberDays = schedule.Count();
        int workDays = CountWorkDays(schedule);
        int averageProduction = schedule.Sum() / workDays;
        int remainingProduction = schedule.Sum() - averageProduction * workDays;
        int[] distributed = new int[numberDays];
        for (int i = 0; i < numberDays; i++)
        {
            if (schedule[i] > 0)
            {
                distributed[i] += averageProduction;
            }

        }
        var daysProdMap = new Dictionary<int, int>();
        for (int i = 0; i < numberDays; i++)
        {
            daysProdMap.Add(i, schedule[i]);
        }

        var priorityDayProd = daysProdMap.OrderByDescending(kvp => kvp.Value).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        while (remainingProduction > 0)
        {
            foreach (var day in priorityDayProd)
            {
                if (remainingProduction > 0 && day.Value > 0)
                {
                    distributed[day.Key]++;
                    remainingProduction--;
                }
            }
        }

        return distributed;
    }

    private int CountWorkDays(int[] schedule)
    {
        int count = 0;
        foreach (var prod in schedule)
        {
            if (prod > 0)
            {
                count++;
            }
        }
        return count;
    }


}

