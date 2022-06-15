
using EF.Core.Repository.Repository;
using HRMS.EmployeeAPIService.Data;
using HRMS.EmployeeAPIService.Interfaces.Repository;

namespace HRMS.EmployeeAPIService.Repositories
{
    public class EmployeeRepository : CommonRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
