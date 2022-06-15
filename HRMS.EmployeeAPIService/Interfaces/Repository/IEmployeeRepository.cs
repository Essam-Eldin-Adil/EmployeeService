using EF.Core.Repository.Interface.Repository;
using HRMS.EmployeeAPIService.Data;

namespace HRMS.EmployeeAPIService.Interfaces.Repository
{
    public interface IEmployeeRepository:ICommonRepository<Employee>
    {
       
    }
}
