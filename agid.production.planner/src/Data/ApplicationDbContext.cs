
using Microsoft.EntityFrameworkCore;
using Production.Planner.Models;
namespace Production.Planner.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<ProductionScheduleModel> ProductionSchedule { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductionScheduleModel>().ToTable("ProductionSchedule");
    }
}
