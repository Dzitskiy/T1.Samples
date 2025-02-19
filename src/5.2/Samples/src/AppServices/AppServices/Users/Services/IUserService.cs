using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Users.Services
{
    public interface IUserService
    {
        Task<IList<User>> GetAllAsync(CancellationToken token);
        Task<User> GetByIdAsync(Guid id, CancellationToken token);
        Task AddAsync(User entity, CancellationToken token);
        Task UpdateByIdAsync(User entity, CancellationToken token);
        Task DeleteByIdAsync(Guid id, CancellationToken token);
    }
}
