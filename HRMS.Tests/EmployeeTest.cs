using FluentAssertions;
using HRMS.EmployeeAPIService.Data;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HRMS.Tests
{
    public class EmployeeTest
    {
        private readonly Guid _id = Guid.Parse("b3ad2b4e-b2e8-47b2-427c-08da4ea001f7");

        [Fact]
        public async Task Test_Delete_Employee()
        {
            //await using var application = new HRMS.();
            using (var client = new TestClientProvider().httpClient)
            {
                var response = await client.DeleteAsync("/api/Employees/" + _id);
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
            }
        }

        [Fact]
        public async Task Test_Post_Employee()
        {
            //await using var application = new HRMS.();
            using (var client = new TestClientProvider().httpClient)
            {
                var emp = new Employee() { Id = _id, EmpName = "test", BirthDate = DateTime.Now, DepartmentName = "test", PhoneNumber = "test", PositionName = "test", Salary = 0, JoinDate = DateTime.Now };
                var response = await client.PostAsync("/api/Employees"
                    , new StringContent(JsonConvert.SerializeObject(emp), Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
            }
        }

        [Fact]
        public async Task Test_Put_Employee()
        {
            //await using var application = new HRMS.();
            using (var client = new TestClientProvider().httpClient)
            {
                var emp = new Employee() { Id = _id, EmpName = "test", BirthDate = DateTime.Now, DepartmentName = "test", PhoneNumber = "test", PositionName = "test", Salary = 0, JoinDate = DateTime.Now };
                var response = await client.PutAsync("/api/Employees/" + _id
                    , new StringContent(JsonConvert.SerializeObject(emp), Encoding.UTF8, "application/json"));
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(System.Net.HttpStatusCode.NoContent);
            }
        }


        [Fact]
        public async Task Test_Get_All()
        {
            //await using var application = new HRMS.();
            using (var client = new TestClientProvider().httpClient)
            {
                var response = await client.GetAsync("/api/Employees");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            }
        }

        [Fact]
        public async Task Test_Get_Single_Employee()
        {
            //await using var application = new HRMS.();
            using (var client = new TestClientProvider().httpClient)
            {
                var response = await client.GetAsync("/api/Employees/"+_id);
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            }
        }
    }
}
