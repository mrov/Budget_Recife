using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Output;
using Services;

namespace BudgetRecife.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BudgetController : ControllerBase
    {
        private readonly IBudgetService _budgetService;

        public BudgetController(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }
        // GET: Api/Orcamento/Monthly
        [HttpGet("/Monthly")]
        public async Task<ActionResult<List<MontlyValueDTO>>> GetBudgetValuesByMonths()
        {
            return Ok(await _budgetService.GetBudgetValuesByMonths());
        }
    }
}