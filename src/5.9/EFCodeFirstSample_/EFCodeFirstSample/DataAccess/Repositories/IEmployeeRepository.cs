using EFCodeFirstSample.Domain.Entities;
using EFCodeFirstSample.Specifications;
using System.Threading.Tasks;

namespace EFCodeFirstSample.DataAccess.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync(CancellationToken cancellationToken);

        Task<Employee> GetByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<IEnumerable<Employee>> GetBySpecificationAsync(Specification<Employee> specification, CancellationToken cancellationToken);

    }
}
