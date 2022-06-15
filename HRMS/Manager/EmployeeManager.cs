using EF.Core.Repository.Manager;
using HRMS.API.Data;
using HRMS.API.Interfaces.Manager;
using HRMS.API.Repositories;

namespace HRMS.API.Manager
{
    public class EmployeeManager:CommonManager<Employee>, IEmployeeManager
    {
        public EmployeeManager(ApplicationDbContext dbContext) : base(new EmployeeRepository(dbContext))
        {

        }
    }
}
