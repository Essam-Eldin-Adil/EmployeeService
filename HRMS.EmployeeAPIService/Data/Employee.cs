using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using HRMS.EmployeeAPIService.Data;
using System.ComponentModel.DataAnnotations;
using System;

namespace HRMS.EmployeeAPIService.Data
{
    [Table("employees")]
    public class Employee
    {
        public Guid Id { get; set; }
        [StringLength(100,MinimumLength =3)]
        [Required(ErrorMessage = "Employee name is requied!!")]
        public string EmpName { get; set; } = string.Empty;


        [StringLength(15)]
        public string PhoneNumber { get; set; } = string.Empty;


        [DataType(DataType.Date,ErrorMessage = "invalid date!")]
        [Required(ErrorMessage = "Birth Date is requied!!")]
        public DateTime BirthDate { get; set; }


        [DataType(DataType.Date, ErrorMessage = "invalid date!")]
        [Required(ErrorMessage = "Join Date is requied!!")]
        public DateTime JoinDate { get; set; } = DateTime.Now.Date;


        [Required(ErrorMessage = "Salary is requied!!")]
        public decimal Salary { get; set; }
        
        [Required(ErrorMessage = "Department name is requied!!")]
        public string DepartmentName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Position name is requied!!")]
        public string PositionName { get; set; } = string.Empty;

    }
}
