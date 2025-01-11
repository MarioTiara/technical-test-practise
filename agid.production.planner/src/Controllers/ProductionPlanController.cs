using System.Text.Json;
using agid.production.planner.Requests;
using Microsoft.AspNetCore.Mvc;
using Production.Planner.Services;

namespace agid.production.planner.Controllers;

public class ProductionPlanController : Controller
{
    private readonly ILogger<ProductionPlanController> _logger;
    private readonly IProductionPlanService _productionPlanService;
    private readonly IProductionPlanViewService _productionViewService;

    public ProductionPlanController(ILogger<ProductionPlanController> logger, IProductionPlanService productionPlanService,
     IProductionPlanViewService productionViewService)
    {
        _logger = logger;
        _productionPlanService = productionPlanService;
        _productionViewService = productionViewService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("/api/production-plan/list")]
    public async Task<JsonResult> GetPlanList()
    {
        var data = await _productionViewService.GetDataView();
        return Json(new
        {
            data = data,
            draw = Request.Query["draw"],
            recordsFiltered = 0,
            recordsTotal = 0
        });
    
    }

    [HttpPost("/api/production-plan/add")]
    public async Task<IActionResult> AddAsync(AddProductionPlanRequest request)
    {
        try
        {
            _productionPlanService.Add(request.tahun, request.mingguKe, request.rencanaProduksiHarian);
            await _productionPlanService.SaveRencanaProduksiHarianAsync();
            return Ok("saved successfully");
        }
        catch (Exception err)
        {
            _logger.LogError(err, err.Message);
            return StatusCode(500);
        }
    }
}