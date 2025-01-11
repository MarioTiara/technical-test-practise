using Production.Planner.Data;
using Production.Planner.Dtos;
using Production.Planner.Models;

namespace Production.Planner.Services;

public interface IProductionPlanViewService
{
    Task<List<ProductPlanView>> GetDataView();
}
public class ProductionPlanViewService:IProductionPlanViewService
{
    private readonly IRepository<ProductionScheduleModel> _repository;
    public ProductionPlanViewService(IRepository<ProductionScheduleModel> repository)
    => _repository = repository;

    public async  Task<List<ProductPlanView>> GetDataView()
    {
        // Group by week number
        var productionSchedules = await _repository.GetAllAsync();
        var groupedByWeek = productionSchedules
            .GroupBy(s => new { s.Tahun, s.MingguKe })
            .OrderBy(g => g.Key.MingguKe); // Sort by week number

        var result = new List<ProductPlanView>();
        foreach (var weekGroup in groupedByWeek)
        {
            // Initialize production values for each day
            int[] senin = new int[2], selasa = new int[2], rabu = new int[2], kamis = new int[2], jumat = new int[2], sabtu = new int[2], minggu = new int[2];
            // Map production values based on the day
            foreach (var schedule in weekGroup)
            {
                switch (schedule.Hari)
                {
                    case Days.Senin:
                        senin[0] = schedule.PlannedProduction;
                        senin[1] = schedule.ActualProduction;
                        break;
                    case Days.Selasa:
                        selasa[0] = schedule.PlannedProduction;
                        selasa[1] = schedule.ActualProduction;
                        break;
                    case Days.Rabu:
                        rabu[0] = schedule.PlannedProduction;
                        rabu[1] = schedule.ActualProduction;
                        break;
                    case Days.Kamis:
                        kamis[0] = schedule.PlannedProduction;
                        kamis[1] = schedule.ActualProduction;
                        break;
                    case Days.Jumat:
                        jumat[0] = schedule.PlannedProduction;
                        jumat[1] = schedule.ActualProduction;
                        break;
                    case Days.Sabtu:
                        sabtu[0] = schedule.PlannedProduction;
                        sabtu[1] = schedule.ActualProduction;
                        break;
                    case Days.Minggu:
                        minggu[0] = schedule.PlannedProduction;
                        minggu[1] = schedule.ActualProduction;
                        break;
                }
            }

            // Create ProductPlanView for the current week
            var productPlanView = new ProductPlanView(
                tahun:weekGroup.Key.Tahun,
                mingguKe: $"Minggu {weekGroup.Key.MingguKe}",
                Senin: senin,
                Selasa: selasa,
                Rabu: rabu,
                Kamis: kamis,
                Jumat: jumat,
                Sabtu: sabtu,
                Minggu: minggu
            );

            result.Add(productPlanView);
        }

        return result;
    }
}

