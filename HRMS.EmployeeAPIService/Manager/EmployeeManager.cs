using EF.Core.Repository.Manager;
using HRMS.EmployeeAPIService.Data;
using HRMS.EmployeeAPIService.Interfaces.Manager;
using HRMS.EmployeeAPIService.Repositories;

namespace HRMS.EmployeeAPIService.Manager
{
    public class EmployeeManager:CommonManager<Employee>, IEmployeeManager
    {
        public EmployeeManager(ApplicationDbContext dbContext) : base(new EmployeeRepository(dbContext))
        {

        }
    }
}
