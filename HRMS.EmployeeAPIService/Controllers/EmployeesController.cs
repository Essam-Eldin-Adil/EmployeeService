using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRMS.EmployeeAPIService.Data;
using HRMS.EmployeeAPIService.Manager;
using Microsoft.AspNetCore.Authorization;

namespace HRMS.EmployeeAPIService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        EmployeeManager _employeeManager;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
            _employeeManager = new EmployeeManager(context);
        }

        // GET: api/Employees
        [HttpGet]
        //[Authorize]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
          if (_employeeManager == null)
          {
              return NotFound();
          }
            var emps = await _employeeManager.GetAllAsync();
            return  emps.ToList();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(Guid id)
        {
          if (_employeeManager == null)
          {
              return NotFound();
          }
            var employee = await _employeeManager.GetFirstOrDefaultAsync(c=>c.Id==id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(Guid id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            

            try
            {
                await _employeeManager.UpdateAsync(employee);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
          if (_employeeManager == null)
          {
              return Problem("Entity set 'Employee Manager'  is null.");
          }
           await _employeeManager.AddAsync(employee);

            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            if (_employeeManager == null)
            {
                return NotFound();
            }
            var employee = await _employeeManager.GetFirstOrDefaultAsync(c=>c.Id==id);
            if (employee == null)
            {
                return NotFound();
            }

            await _employeeManager.DeleteAsync(employee);

            return NoContent();
        }

        private bool EmployeeExists(Guid id)
        {
            return (_employeeManager?.GetFirstOrDefault(e => e.Id == id))==null?false:true;
        }
    }
}
