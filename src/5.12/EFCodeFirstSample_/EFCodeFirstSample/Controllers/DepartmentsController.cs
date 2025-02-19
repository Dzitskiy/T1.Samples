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
            var users = await _context.Departments.AsNoTracking()
                .Include(dep => dep.Employees)
                .ToListAsync();

            return Ok(users);
        }

        /**/
        [HttpGet("{id}/emp")]
        public async Task<ActionResult<Employee>> GetEmployee(Guid id)
        {
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            var result = department.Employees;

            return Ok(result);
        }
        /**/
    }
}
