using EFCodeFirstSample.DataAccess;
using EFCodeFirstSample.DataAccess.Repositories;
using EFCodeFirstSample.Domain.Entities;
using EFCodeFirstSample.Models;
using EFCodeFirstSample.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EFCodeFirstSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;

        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            // _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            //var query = _context.Employees.AsNoTracking()
            //    .Include(e => e.Department);

            //var users = await query.ToListAsync();

            var users = await _employeeRepository.GetAll();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(Guid id, CancellationToken cancellationToken)
        {
            //var employee = await _context.Employees.FindAsync(id);

            //var query = _context.Employees
            //    .AsNoTracking()
            //    .Include(e => e.Department)
            //    .Where(e => e.Id == id);

            //Console.BackgroundColor = ConsoleColor.Cyan;
            //Console.WriteLine(query.Expression.ToString());
            //Console.BackgroundColor = ConsoleColor.White;

            //var employee = await query.FirstOrDefaultAsync();


            var employee = await _employeeRepository.GetByIdAsync(id, cancellationToken);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        [HttpGet]
        [Route("by-name")]

        public async Task<IActionResult> GetAllByName([FromQuery] EmployeesByNameRequest request, CancellationToken cancellationToken)
        {
            Specification<Employee> specification = new ByNameSpecification(request.Name);

            var result = await _employeeRepository.GetBySpecificationAsync(specification, cancellationToken);

            return Ok(result);
        }
    }
}

