using Company.Core.Models;
using Company.Core.Services;
using Company.Repository.Entities;
using Company.Web.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Company.Web.Api.Tests
{
    public class EmployeeControllerTest
    {
        private readonly Mock<IEmployeeService> _mockEmployeeService;
        private readonly EmployeeController _employeeController;

        public EmployeeControllerTest()
        {
            _mockEmployeeService = new Mock<IEmployeeService>();
            _employeeController = new EmployeeController(_mockEmployeeService.Object);
        }

        [Fact]
        public async Task Get_ReturnsOkResult()
        {
            // Arrange
            var employees = new List<EmployeeResponse>
            {
                new EmployeeResponse{ FirstName = "Anna", LastName = "Ray", DateOfBirth = DateTime.Now.AddYears(-30), Id = 1 },
                new EmployeeResponse{ FirstName = "Moory", LastName = "Jay", DateOfBirth = DateTime.Now.AddYears(-27), Id = 2 },
            };
            _mockEmployeeService.Setup(service => service.GetAllEmployees()).ReturnsAsync(employees);

            // Act
            var result = await _employeeController.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<EmployeeResponse>>(okResult.Value);
            Assert.Equal(employees.Count, model.Count());
        }

        [Fact]
        public async Task Post_ReturnsOkResult()
        {
            // Arrange
            var request = new AddEmployeeRequest
            {
                FirstName = "DJ",
                LastName = "Dan",
                DateOfBirth = DateTime.Now.AddYears(-20)
            };
            _mockEmployeeService.Setup(service => service.AddEmployee(request)).ReturnsAsync(true);

            // Act
            var result = await _employeeController.Post(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
        }

    }
}
