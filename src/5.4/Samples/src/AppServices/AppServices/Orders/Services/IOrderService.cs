using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Orders.Services
{
    internal interface IOrderService
    {
        Task<IList<Order>> GetAllAsync(CancellationToken token);
        Task<Order> GetByIdAsync(Guid id, CancellationToken token);
        Task AddAsync(Order entity, CancellationToken token);
        Task UpdateByIdAsync(Order entity, CancellationToken token);
        Task DeleteByIdAsync(Guid id, CancellationToken token);
    }
}
