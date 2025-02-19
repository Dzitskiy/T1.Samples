using EFDatabaseFirstSample.Data;
using EFDatabaseFirstSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFDatabaseFirstSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly TestDbContext _context;

        public UserController(TestDbContext context)
        {
            _context = context;
        }

        [HttpGet(Name = "test")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _context.Users
                .Include(u => u.UserProfile)
                .Include(u => u.Orders)
                .ThenInclude(o => o.Products)
                .ToListAsync();

           return  Ok(users);
        }
    }
}
