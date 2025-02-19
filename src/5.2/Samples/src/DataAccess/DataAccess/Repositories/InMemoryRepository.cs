using Domain;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
    {
        protected IList<T> Data { get; set; }

        public InMemoryRepository(IList<T> data) {
            Data = data;
        }

        public Task<IList<T>> GetAllAsync(CancellationToken token)
        {
           return Task.FromResult(Data);
        }

        public Task<T> GetByIdAsync(Guid id, CancellationToken token)
        {
            return Task.FromResult(Data.FirstOrDefault(x => x.Id == id));
        }

        public Task AddAsync(T entity, CancellationToken token)
        {
            Data.Add(entity);
            return Task.CompletedTask;
        }
        public Task UpdateByIdAsync(Guid id, T entity, CancellationToken token)
        {
            Data[Data.IndexOf(Data.FirstOrDefault(x => x.Id == id))] = entity;
            return Task.CompletedTask;
        }

        public Task DeleteByIdAsync(Guid id, CancellationToken token)
        {
            Data.Remove(Data.FirstOrDefault(x => x.Id == id));
            return Task.CompletedTask;
        }

        public Task<bool> Exists(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
