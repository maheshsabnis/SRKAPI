

using Com.Application.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
namespace APIUnitTest
{
    public class DepartmentControllerUnitTest
    {
        [Fact]
        public void Should_Return_Dept_based_on_DeptNo()
        {
            // 1. Arrange: Create a Mock for Dependency for DepartmentController
            var mock = new Mock<IDbAccess<Department,int>>();
            var controller = new DepartmentController(mock.Object);
            int id = 20;

            // 2. Act
            var result = controller.Get(id).Result;

            // 2. Assertion
            //Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

        }
    }
}