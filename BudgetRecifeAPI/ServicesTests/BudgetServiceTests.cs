using Models.DTOs.Output;
using Moq;
using Repository;
using Services;

namespace ServicesTests
{
    public class BudgetServiceTests
    {
        [Fact]
        public async Task GetBudgetValuesByMonths_ShouldReturnListOfMonthlyValueDTO()
        {
            // Arrange
            var mockRepository = new Mock<IBudgetRepository>();
            var expectedValues = new List<MonthlyValueDTO> {
                new MonthlyValueDTO { Month = 1, TotalMonthValue = 100 },
                new MonthlyValueDTO { Month = 2, TotalMonthValue = 200 },
                new MonthlyValueDTO { Month = 3, TotalMonthValue = 300 }
            };
            mockRepository.Setup(repo => repo.GetBudgetValuesByMonths()).ReturnsAsync(expectedValues);
            var service = new BudgetService(mockRepository.Object);

            // Act
            var result = await service.GetBudgetValuesByMonths();

            // Assert
            Assert.Equal(expectedValues, result);
        }

        [Fact]
        public async Task GetBudgetValuesByCategory_ShouldReturnListOfEconomicCategoryDTO()
        {
            // Arrange
            var mockRepository = new Mock<IBudgetRepository>();
            var expectedValues = new List<EconomicCategoryDTO> {
                new EconomicCategoryDTO { EconomicCategoryCode = 1, EconomicCategoryName = "Category 1", TotalCategoryValue = 400 },
                new EconomicCategoryDTO { EconomicCategoryCode = 2, EconomicCategoryName = "Category 2", TotalCategoryValue = 200 }
            };
            mockRepository.Setup(repo => repo.GetBudgetValuesByCategory()).ReturnsAsync(expectedValues);
            var service = new BudgetService(mockRepository.Object);

            // Act
            var result = await service.GetBudgetValuesByCategory();

            // Assert
            Assert.Equal(expectedValues, result);
        }

        [Fact]
        public async Task GetBudgetValuesBySource_ShouldReturnListOfResourceSourceDTO()
        {
            // Arrange
            var mockRepository = new Mock<IBudgetRepository>();
            var expectedValues = new List<ResourceSourceDTO> {
                new ResourceSourceDTO { ResourceSourceCode = 1, ResourceSourceName = "Source 1", TotalSourceValue = 400 },
                new ResourceSourceDTO { ResourceSourceCode = 2, ResourceSourceName = "Source 2", TotalSourceValue = 200 }
            };
            mockRepository.Setup(repo => repo.GetBudgetValuesBySource()).ReturnsAsync(expectedValues);
            var service = new BudgetService(mockRepository.Object);

            // Act
            var result = await service.GetBudgetValuesBySource();

            // Assert
            Assert.Equal(expectedValues, result);
        }
    }
}