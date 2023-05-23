using Microsoft.EntityFrameworkCore;
using Models;
using Models.DTOs.Output;
using Repository;

public class BudgetRepositoryTests
{
    private readonly DbContextOptions<MyDbContext> _dbContextOptions;
    private readonly IBudgetRepository _budgetRepository;

    public BudgetRepositoryTests()
    {
        _dbContextOptions = new DbContextOptionsBuilder<MyDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        _budgetRepository = new BudgetRepository(new MyDbContext(_dbContextOptions));
    }

    [Fact]
    public async Task GetBudgetValuesByMonths_ShouldReturnListOfMonthlyValueDTO()
    {
        // Arrange
        using (var context = new MyDbContext(_dbContextOptions))
        {
            var budgets = new List<Budget>
            {
                new Budget { mes_movimentacao = 1, valor_liquidado = "100" },
                new Budget { mes_movimentacao = 2, valor_liquidado = "200" },
                new Budget { mes_movimentacao = 3, valor_liquidado = "300" }
            };
            context.Budgets.AddRange(budgets);
            context.SaveChanges();
        }

        var expectedResults = new List<MonthlyValueDTO>
        {
            new MonthlyValueDTO { Month = 1, TotalMonthValue = 100 },
            new MonthlyValueDTO { Month = 2, TotalMonthValue = 200 },
            new MonthlyValueDTO { Month = 3, TotalMonthValue = 300 }
        };

        // Act
        var result = await _budgetRepository.GetBudgetValuesByMonths();

        // Assert
        Assert.Equal(expectedResults.Count, result.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i].Month, result[i].Month);
            Assert.Equal(expectedResults[i].TotalMonthValue, result[i].TotalMonthValue);
        }
    }

    [Fact]
    public async Task GetBudgetValuesByCategory_ShouldReturnListOfEconomicCategoryDTO()
    {
        // Arrange
        using (var context = new MyDbContext(_dbContextOptions))
        {
            var budgets = new List<Budget>
            {
                new Budget { categoria_economica_codigo = 1, categoria_economica_nome = "Category 1", valor_liquidado = "100" },
                new Budget { categoria_economica_codigo = 2, categoria_economica_nome = "Category 2", valor_liquidado = "200" },
                new Budget { categoria_economica_codigo = 1, categoria_economica_nome = "Category 1", valor_liquidado = "300" }
            };
            context.Budgets.AddRange(budgets);
            context.SaveChanges();
        }

        var expectedResults = new List<EconomicCategoryDTO>
        {
            new EconomicCategoryDTO { EconomicCategoryCode = 1, EconomicCategoryName = "Category 1", TotalCategoryValue = 400 },
            new EconomicCategoryDTO { EconomicCategoryCode = 2, EconomicCategoryName = "Category 2", TotalCategoryValue = 200 }
        };

        // Act
        var result = await _budgetRepository.GetBudgetValuesByCategory();

        // Assert
        Assert.Equal(expectedResults.Count, result.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i].EconomicCategoryCode, result[i].EconomicCategoryCode);
            Assert.Equal(expectedResults[i].EconomicCategoryName, result[i].EconomicCategoryName);
            Assert.Equal(expectedResults[i].TotalCategoryValue, result[i].TotalCategoryValue);
        }
    }

    [Fact]
    public async Task GetBudgetValuesBySource_ShouldReturnListOfResourceSourceDTO()
    {
        // Arrange
        using (var context = new MyDbContext(_dbContextOptions))
        {
            var budgets = new List<Budget>
            {
                new Budget { fonte_recurso_codigo = 1, fonte_recurso_nome = "Source 1", valor_liquidado = "100" },
                new Budget { fonte_recurso_codigo = 2, fonte_recurso_nome = "Source 2", valor_liquidado = "200" },
                new Budget { fonte_recurso_codigo = 1, fonte_recurso_nome = "Source 1", valor_liquidado = "300" }
            };
            context.Budgets.AddRange(budgets);
            context.SaveChanges();
        }

        var expectedResults = new List<ResourceSourceDTO>
        {
            new ResourceSourceDTO { ResourceSourceCode = 1, ResourceSourceName = "Source 1", TotalSourceValue = 400 },
            new ResourceSourceDTO { ResourceSourceCode = 2, ResourceSourceName = "Source 2", TotalSourceValue = 200 }
        };

        // Act
        var result = await _budgetRepository.GetBudgetValuesBySource();

        // Assert
        Assert.Equal(expectedResults.Count, result.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i].ResourceSourceCode, result[i].ResourceSourceCode);
            Assert.Equal(expectedResults[i].ResourceSourceName, result[i].ResourceSourceName);
            Assert.Equal(expectedResults[i].TotalSourceValue, result[i].TotalSourceValue);
        }
    }
}