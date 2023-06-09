﻿using Microsoft.EntityFrameworkCore;
using Models.DTOs.Output;

namespace Repository
{
    // Repository interface
    public interface IBudgetRepository
    {
        Task<List<MonthlyValueDTO>> GetBudgetValuesByMonths();
        Task<List<EconomicCategoryDTO>> GetBudgetValuesByCategory();
        Task<List<ResourceSourceDTO>> GetBudgetValuesBySource();
    }

    // Repository implementation
    public class BudgetRepository : IBudgetRepository
    {
        private readonly MyDbContext _context;

        public BudgetRepository(MyDbContext context)
        {
            _context = context;
        }
        public async Task<List<MonthlyValueDTO>> GetBudgetValuesByMonths()
        {
            var result = await _context.Budgets.GroupBy(o => o.mes_movimentacao).Select(month => new MonthlyValueDTO
            {
                Month = month.Key,
                TotalMonthValue = month.Sum(orc => (long)Convert.ToDouble(orc.valor_liquidado.Replace(",", ".")))
            }).OrderBy(mon => mon.Month).ToListAsync();

            return result;
        }

        public async Task<List<EconomicCategoryDTO>> GetBudgetValuesByCategory()
        {
            var result = await _context.Budgets.GroupBy(o => new { o.categoria_economica_codigo, o.categoria_economica_nome }).Select(category => new EconomicCategoryDTO
            {
                EconomicCategoryCode = category.Key.categoria_economica_codigo,
                EconomicCategoryName = category.Key.categoria_economica_nome,
                TotalCategoryValue = category.Sum(orc => (long)Convert.ToDouble(orc.valor_liquidado.Replace(",", ".")))
            }).OrderBy(eco => eco.EconomicCategoryCode).ToListAsync();

            return result;
        }

        public async Task<List<ResourceSourceDTO>> GetBudgetValuesBySource()
        {
            var result = await _context.Budgets.GroupBy(o => new { o.fonte_recurso_codigo, o.fonte_recurso_nome }).Select(resourceSource => new ResourceSourceDTO
            {
                ResourceSourceCode = resourceSource.Key.fonte_recurso_codigo,
                ResourceSourceName = resourceSource.Key.fonte_recurso_nome,
                TotalSourceValue = resourceSource.Sum(orc => (long)Convert.ToDouble(orc.valor_liquidado.Replace(",", ".")))
            }).OrderByDescending(res => res.TotalSourceValue).ToListAsync();

            return result;
        }
    }
}