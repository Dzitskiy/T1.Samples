using EFCodeFirstSample.Domain.Entities;
using EFCodeFirstSample.Specifications;
using Microsoft.EntityFrameworkCore;

namespace EFCodeFirstSample.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Employee>> GetAll()
        {
        
            var query = _context.Employees.AsNoTracking()
                .Include(e => e.Department);

            var users = await query.ToListAsync();

            return (users);
        }

        public async Task<IEnumerable<Employee>> GetBySpecificationAsync(Specification<Employee> specification, CancellationToken cancellationToken)
        {
            return await _context.Employees
                .Where(specification.ToExpression())
                .ToArrayAsync(cancellationToken);
        }

        public async Task<Employee> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            //var employee = await _context.Employees.FindAsync(id);

            var query = _context.Employees
                .AsNoTracking()
                .Include(e => e.Department)
                .Where(e => e.Id == id);

            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine(query.Expression.ToString());
            Console.BackgroundColor = ConsoleColor.White;

            var employee = await query.FirstOrDefaultAsync();

            return employee;
        }

    }
}
