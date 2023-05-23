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
        [HttpGet("/Monthly")]
        public async Task<ActionResult<List<MontlyValueDTO>>> GetBudgetValuesByMonths()
        {
            return Ok(await _budgetService.GetBudgetValuesByMonths());
        }

        // GET: Api/Budget/Categories
        [HttpGet("/ByCategories")]
        public async Task<ActionResult<List<EconomicCategoryDTO>>> GetBudgetValuesByCategory()
        {
            // Return a string as the response
            return Ok(await _budgetService.GetBudgetValuesByCategory());
        }
    }
}