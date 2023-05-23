using BudgetRecife.Controllers;
using Microsoft.AspNetCore.Mvc;
using Models.DTOs.Output;
using Moq;
using Services;

public class BudgetControllerTests
{
    [Fact]
    public async Task GetBudgetValuesByMonths_ReturnsOkResultWithListOfMonthlyValueDTO()
    {
        // Arrange
        var mockService = new Mock<IBudgetService>();
        var expectedValues = new List<MonthlyValueDTO> {
            new MonthlyValueDTO { Month = 1, TotalMonthValue = 100 },
            new MonthlyValueDTO { Month = 2, TotalMonthValue = 200 },
            new MonthlyValueDTO { Month = 3, TotalMonthValue = 300 }
        };
        mockService.Setup(service => service.GetBudgetValuesByMonths()).ReturnsAsync(expectedValues);
        var controller = new BudgetController(mockService.Object);

        // Act
        var result = await controller.GetBudgetValuesByMonths();

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
        var okResult = result.Result as OkObjectResult;
        Assert.Equal(expectedValues, okResult.Value);
    }

    [Fact]
    public async Task GetBudgetValuesByCategory_ReturnsOkResultWithListOfEconomicCategoryDTO()
    {
        // Arrange
        var mockService = new Mock<IBudgetService>();
        var expectedValues = new List<EconomicCategoryDTO> {
            new EconomicCategoryDTO { EconomicCategoryCode = 1, EconomicCategoryName = "Category 1", TotalCategoryValue = 400 },
            new EconomicCategoryDTO { EconomicCategoryCode = 2, EconomicCategoryName = "Category 2", TotalCategoryValue = 200 }
        };
        mockService.Setup(service => service.GetBudgetValuesByCategory()).ReturnsAsync(expectedValues);
        var controller = new BudgetController(mockService.Object);

        // Act
        var result = await controller.GetBudgetValuesByCategory();

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
        var okResult = result.Result as OkObjectResult;
        Assert.Equal(expectedValues, okResult.Value);
    }

    [Fact]
    public async Task GetBudgetValuesBySource_ReturnsOkResultWithListOfResourceSourceDTO()
    {
        // Arrange
        var mockService = new Mock<IBudgetService>();
        var expectedValues = new List<ResourceSourceDTO> {
            new ResourceSourceDTO { ResourceSourceCode = 1, ResourceSourceName = "Source 1", TotalSourceValue = 400 },
            new ResourceSourceDTO { ResourceSourceCode = 2, ResourceSourceName = "Source 2", TotalSourceValue = 200 }
        };
        mockService.Setup(service => service.GetBudgetValuesBySource()).ReturnsAsync(expectedValues);
        var controller = new BudgetController(mockService.Object);

        // Act
        var result = await controller.ResourceBySource();

        // Assert
        Assert.IsType<OkObjectResult>(result.Result);
        var okResult = result.Result as OkObjectResult;
        Assert.Equal(expectedValues, okResult.Value);
    }
}