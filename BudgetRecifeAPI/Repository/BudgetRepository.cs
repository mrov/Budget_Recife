using Microsoft.EntityFrameworkCore;
using Models.DTOs.Output;

namespace Repository
{
    // Repository interface
    public interface IBudgetRepository
    {
        Task<List<MontlyValueDTO>> GetBudgetValuesByMonths();
    }

    // Repository implementation
    public class BudgetRepository : IBudgetRepository
    {
        private readonly MyDbContext _context;

        public BudgetRepository(MyDbContext context)
        {
            _context = context;
        }
        public async Task<List<MontlyValueDTO>> GetBudgetValuesByMonths()
        {
            var result = await _context.Budgets.GroupBy(o => o.mes_movimentacao).Select(month => new MontlyValueDTO
            {
                Month = month.Key,
                TotalMonthValue = month.Sum(orc => (long)Convert.ToDouble(orc.valor_liquidado.Replace(",", ".")))
            }).OrderBy(mon => mon.Month).ToListAsync();

            return result;
        }

    }
}