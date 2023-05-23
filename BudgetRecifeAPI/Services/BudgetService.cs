using Models.DTOs.Output;
using Repository;

namespace Services
{
    // Service interface
    public interface IBudgetService
    {
        Task<List<MontlyValueDTO>> GetBudgetValuesByMonths();
        Task<List<EconomicCategoryDTO>> GetBudgetValuesByCategory();
        Task<List<ResourceSourceDTO>> GetBudgetValuesBySource();
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

        public async Task<List<EconomicCategoryDTO>> GetBudgetValuesByCategory()
        {
            return await _BudgetRepository.GetBudgetValuesByCategory();
        }

        public async Task<List<ResourceSourceDTO>> GetBudgetValuesBySource()
        {
            return await _BudgetRepository.GetBudgetValuesBySource();
        }
    }
}