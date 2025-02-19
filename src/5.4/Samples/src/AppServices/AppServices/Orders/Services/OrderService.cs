using AppServices.Users.Services;
using DataAccess;
using Domain;
using Infrastructure.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Orders.Services
{
    internal class OrderService : IOrderService
    {
        //private readonly IRepository<Order> _orderRepository;
        //private readonly IRepository<User> _userRepository;

        private readonly IUnitOfWork _unitOfWork;

        private readonly ILogger<OrderService> _logger;

        public OrderService(
            IRepository<Order> orderRepository,
            IRepository<User> userRepository,
            ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<IList<Order>> GetAllAsync(CancellationToken token)
        {
            
            
            var data = await _orderRepository.GetAllAsync(token);

            var user = data.FirstOrDefault();

            //var user = await _userRepository.GetByIdAsync(user.Id, token);



            if (data == null || data.Count == 0)
            {
                _logger.LogError("List is empty!");
            }
            return data;
        }

        public async Task<Order> GetByIdAsync(Guid id, CancellationToken token)
        {
            return await _orderRepository.GetByIdAsync(id, token);
        }

        public async Task AddAsync(Order entity, CancellationToken token)
        {
            await _orderRepository.AddAsync(entity, token);
        }
        public async Task UpdateByIdAsync(Order entity, CancellationToken token)
        {
            if (!await _orderRepository.Exists(entity.Id))
            {
                _logger.LogError($"Not find entity by Id: {entity.Id} !");
            }

            await _orderRepository.UpdateByIdAsync(entity.Id, entity, token);
        }

        public async Task DeleteByIdAsync(Guid id, CancellationToken token)
        {
            if (!await _orderRepository.Exists(id))
            {
                _logger.LogError($"Not find entity by Id: {id} !");
            }

            await _orderRepository.DeleteByIdAsync(id, token);
        }


    }
}
