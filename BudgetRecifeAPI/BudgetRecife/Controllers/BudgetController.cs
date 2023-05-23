using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Output;
using Services;

namespace BudgetRecife.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetService _budgetService;

        public BudgetController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }

        // GET: Api/Budget/Monthly
        [HttpGet("Monthly")]
        public async Task<ActionResult<List<MonthlyValueDTO>>> GetBudgetValuesByMonths()
        {
            return Ok(await _budgetService.GetBudgetValuesByMonths());
        }

        // GET: Api/Budget/ByCategories
        [HttpGet("ByCategories")]
        public async Task<ActionResult<List<EconomicCategoryDTO>>> GetBudgetValuesByCategory()
        {
            return Ok(await _budgetService.GetBudgetValuesByCategory());
        }

        // GET: Api/Budget/BySource
        [HttpGet("BySource")]
        public async Task<ActionResult<List<ResourceSourceDTO>>> ResourceBySource()
        {
            return Ok(await _budgetService.GetBudgetValuesBySource());
        }
    }
}