using EFCodeFirstSample.DataAccess;
using EFCodeFirstSample.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirstSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DepartmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetDepartments()
        {
            var departments = await _context.Departments.AsNoTracking()
                //.Include(d => d.Employees)
                .ToListAsync();

            return Ok(departments);
        }

        [HttpGet("{id}/employees")]
        public async Task<ActionResult<Department>> GetDepartment(Guid id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            var result = department.Employees;

            return Ok(result);
        }
    }
}
