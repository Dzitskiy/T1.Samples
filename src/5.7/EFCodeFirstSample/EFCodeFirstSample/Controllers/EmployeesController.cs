using EFCodeFirstSample.DataAccess;
using EFCodeFirstSample.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EFCodeFirstSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("/salary")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetMaxSalaryEmployees()
        {
            /*
select e.*  from "Employees" e 
join (
select "DepartmentId", max("Salary") as MaxSalary
from "Employees"
group by "DepartmentId") as ms 
on e."DepartmentId" = ms."DepartmentId" and e."Salary" = ms.MaxSalary;
            */

            //var result = from emp in _context.Employees ;

            var maxSalary = from e in _context.Employees
                            group e by e.DepartmentId into g
                            select new { DepartmentId = g.Key, MaxSalary = g.Max(x => x.Salary) };

            var maxSalaryEmployees = (from e in _context.Employees
                                      join ms in maxSalary on new { e.DepartmentId, e.Salary }
                                      equals new { ms.DepartmentId, Salary = ms.MaxSalary }
                                      select e).ToList();

            return Ok(maxSalaryEmployees);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            var users = await _context.Employees.AsNoTracking()
                .Include(e => e.Department)               
                .ToListAsync();

            return Ok(users);
        }

        [HttpGet("{id}/department")]
        public async Task<ActionResult<Employee>> GetEmployee(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            var result = employee.Department;

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Createemployee(Employee employee)
        {
            _context.Employees.Add(employee);

            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateEmployee(Employee employee)
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            var currentEmployee = await _context.Employees.FindAsync(employee.Id);

         

            if (currentEmployee != null)
            {
                currentEmployee.FirstName = employee.FirstName;
                currentEmployee.LastName = employee.LastName;

                await _context.SaveChangesAsync();

                return Ok(currentEmployee);
            }

            return NotFound(employee);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var currentEmployee = await _context.Employees.FindAsync(id);

            if (currentEmployee != null)
            {
                _context.Employees.Remove(currentEmployee);
                await _context.SaveChangesAsync();

                return Ok(currentEmployee);
            }

            return NotFound(id);
        }
    }
}
