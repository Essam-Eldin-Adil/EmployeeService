using HRMS.EmployeeAPIService.Data;
using System;

namespace WebApi.Test.Booking
{
    public static class EmployeeData
    {
        public static Employee MockCreateEmployeeCommand() => new()
        {
            JoinDate = DateTime.Now,
            BirthDate = DateTime.Now.AddDays(30),
            Salary = 10000,
            DepartmentName = "IT",
            PositionName="Software developer",
            PhoneNumber="+249913319739",
            EmpName = "Essam eldin adil"
        };
    }
}