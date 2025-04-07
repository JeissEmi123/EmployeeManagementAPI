using EmployeeManagementAPI.Models;
using EmployeeManagementAPI.Services;
using EmployeeManagementAPI.Repositories;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using EmployeeManagementAPI.Dtos;

namespace EmployeeManagementAPI.Tests
{
    public class EmployeeServiceTests
    {
        private Mock<IEmployeeRepository> _employeeRepositoryMock;
        private EmployeeService _employeeService;

        [SetUp]
        public void Setup()
        {
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
            _employeeService = new EmployeeService(_employeeRepositoryMock.Object);
        }

        [Test]
        public async Task CreateEmployeeAsync_ValidData_ReturnsEmployeeDto()
        {
            // Arrange
            var createDto = new CreateEmployeeDto
            {
                Name = "Carlos Pérez",
                Salary = 5000000
            };

            var createdEmployee = new Employee
            {
                Id = 1,
                Name = createDto.Name,
                Salary = createDto.Salary,
                IsActive = true
            };

            _employeeRepositoryMock
                .Setup(r => r.AddAsync(It.IsAny<Employee>()))
                .Callback<Employee>(e => e.Id = 1)
                .Returns(Task.CompletedTask);

            // Act
            var result = await _employeeService.CreateEmployeeAsync(createDto);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Carlos Pérez", result.Name);
            Assert.AreEqual(5000000, result.Salary);
        }
    }
}
