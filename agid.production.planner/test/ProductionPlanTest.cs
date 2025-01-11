
namespace agid.production.planner.test;

using Production.Planner.Models;
using Production.Planner.Services;
public class ProductionPlanServiceTests
{
    [Theory]
    [InlineData(new int[] { 4, 5, 1, 4, 6 }, new int[] { 4, 4, 4, 4, 4 })]
    [InlineData(new int[] { 5, 4, 3, 6, 4 }, new int[] { 5, 4, 4, 5, 4 })]
    [InlineData(new int[] { 5, 6, 3, 6, 4 }, new int[] { 5, 5, 4, 5, 5 })]
    [InlineData(new int[] { 4, 5, 1, 7, 6 }, new int[] { 4, 5, 4, 5, 5 })]
    [InlineData(new int[] { 7, 6, 3, 9, 3 }, new int[] { 6, 6, 5, 6, 5 })]
    public void RedistributeProduction_ShouldRedistributedProductionCorrectly(int[] schedule, int[] expected)
    {

        //Arrange
        var productionPlan = new ProductionPlanService();
        //Act
        var result = productionPlan.DistribusiProduksiHarian;
        //Assert
        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData(new int[] { 4, 5, 1, 7, 6, 4, 0 }, new int[] { 4, 5, 4, 5, 5, 4, 0 })]
    [InlineData(new int[] { 4, 5, 2, 7, 6, 0, 5 }, new int[] { 5, 5, 4, 5, 5, 0, 5 })]
    [InlineData(new int[] { 0, 5, 1, 7, 6, 4, 4 }, new int[] { 0, 5, 4, 5, 5, 4, 4 })]
    [InlineData(new int[] { 4, 6, 1, 7, 6, 5, 0 }, new int[] { 5, 5, 4, 5, 5, 5, 0 })]
    public void RedistributeProduction_ShouldNotDistributedOnZeroPlanning(int[] schedule, int[] expected)
    {

        //Arrange
        var productionPlan = new ProductionPlanService(1, schedule);
        //Act
        var result = productionPlan.DistribusiProduksiHarian;
        //Assert
        Assert.Equal(expected, result);
    }
}