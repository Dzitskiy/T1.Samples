using EFCodeFirstSample.DataAccess;
using EFCodeFirstSample.DataAccess.Repositories;
using EFCodeFirstSample.Domain.Entities;
using EFCodeFirstSample.Models;
using EFCodeFirstSample.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirstSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IEmployeeRepository _employeeRepository;


        public EmployeesController(
            //ApplicationDbContext context,
            IEmployeeRepository employeeRepository)
        {
            //_context = context;
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees(CancellationToken cancellationToken)
        {
            var users = await _employeeRepository.GetAllAsync(cancellationToken);

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(Guid id, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(id, cancellationToken);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }


        [HttpPost("by-filter")]
        public async Task<ActionResult<Employee>> GetEmployeeByFilter([FromBody] GetByFilterRequest filter, CancellationToken cancellationToken)
        {
            Specification<Employee> specification = new ByFirstNameSpecification(filter.FirstName);

            var result = await _employeeRepository.GetBySpecificationAsync(specification, cancellationToken);

            return Ok(result);
        }

    }
}
