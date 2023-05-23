using Models.DTOs.Output;
using Repository;

namespace Services
{
    // Service interface
    public interface IBudgetService
    {
        Task<List<MontlyValueDTO>> GetBudgetValuesByMonths();
    }

    // Service implementation
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepository _BudgetRepository;

        public BudgetService(IBudgetRepository BudgetRepository)
        {
            _BudgetRepository = BudgetRepository;
        }
        public async Task<List<MontlyValueDTO>> GetBudgetValuesByMonths()
        {
            return await _BudgetRepository.GetBudgetValuesByMonths();
        }

    }
}