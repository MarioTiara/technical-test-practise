using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace Production.Planner.Models;

public class ProductionScheduleModel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int Tahun { get; private set; }
    public int MingguKe { get; private set; }
    public Days Hari { get; private set; }
    public int PlannedProduction { get; private set; }
    public int ActualProduction { get; private set; }

    public ProductionScheduleModel(int tahun, int mingguke, Days hari, int plannedProduction, int actualProduction)
    {
        Tahun = tahun;
        MingguKe = mingguke;
        Hari = hari;
        PlannedProduction = plannedProduction;
        ActualProduction = actualProduction;
    }



    public ProductionScheduleModel()
    {

    }


}