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

        public async Task<IEnumerable<Employee>> GetAllAsync(CancellationToken cancellationToken)
        {
            var query = _context.Employees.AsNoTracking()
                .Include(e => e.Department);

            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(query.Expression.ToString());
            Console.ForegroundColor = ConsoleColor.White;

            return await query.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await  _context.Employees.FindAsync(id);
        }

        public async Task<IEnumerable<Employee>> GetBySpecificationAsync(Specification<Employee> specification, CancellationToken cancellationToken)
        {
            var query = _context.Employees.Where(specification.ToExpression());

            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(query.Expression.ToString());
            Console.ForegroundColor = ConsoleColor.White;

            return await query.ToListAsync(cancellationToken);
        }
    }
}
