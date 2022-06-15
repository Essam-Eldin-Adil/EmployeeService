
using EF.Core.Repository.Repository;
using HRMS.API.Data;
using HRMS.API.Interfaces.Repository;

namespace HRMS.API.Repositories
{
    public class EmployeeRepository : CommonRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
