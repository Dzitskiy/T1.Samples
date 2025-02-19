using Domain;

namespace Infrastructure.Repository
{
    ///public interface IRepository<TEntity, TContext> where TEntity : class where TContext : DbContext
    public interface IRepository<T> where T : BaseEntity        
    {
        Task<IList<T>> GetAllAsync(CancellationToken token);
        Task<T> GetByIdAsync(Guid id, CancellationToken token);
        Task AddAsync(T entity, CancellationToken token);
        Task UpdateByIdAsync(Guid id, T entity, CancellationToken token);
        Task DeleteByIdAsync(Guid id, CancellationToken token);
        Task<bool> Exists(Guid id);
    }
}
