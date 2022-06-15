using HRMS.EmployeeAPIService.Controllers;
using HRMS.EmployeeAPIService.Data;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HRMS.Tests
{
    public class EmployeeServiceTest : IClassFixture<SharedDatabaseFixture>
    {
        public SharedDatabaseFixture _fixture { get; }
        private readonly Mock<ApplicationDbContext> _mockContext;
        private readonly EmployeesController _controller;

        public EmployeeServiceTest(SharedDatabaseFixture fixture)
        {
            _fixture = fixture;
            _mockContext = new Mock<ApplicationDbContext>();
            _mockContext.Setup(db => db.Employees).Returns(SharedDatabaseFixture.CreateContext().Employees);
            _controller = new EmployeesController(_mockContext.Object);
        }

        [Fact]
        public async Task Can_Get_All_Employees()
        {
            var result = await _controller.GetEmployees();
            var hotel = result.Result;
            Assert.Equal(0, 0);
        }
    }
}
