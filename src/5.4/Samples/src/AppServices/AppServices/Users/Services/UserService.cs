using Domain;
using Infrastructure.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppServices.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly ILogger<UserService> _logger;

        public UserService(IRepository<User> userRepository, ILogger<UserService> logger)
        { 
            _userRepository = userRepository;
            _logger = logger;        
        }

        public async Task<IList<User>> GetAllAsync(CancellationToken token)
        {
            var data = await _userRepository.GetAllAsync(token);
            if (data == null || data.Count == 0)
            {
                _logger.LogError("List is empty!");
            }
            return data;
        }

        public async Task<User> GetByIdAsync(Guid id, CancellationToken token)
        {
            return await _userRepository.GetByIdAsync(id, token);
        }

        public async Task AddAsync(User entity, CancellationToken token)
        {
            await _userRepository.AddAsync(entity, token);
        }
        public async Task UpdateByIdAsync(User entity, CancellationToken token)
        {
            if (!await _userRepository.Exists(entity.Id))
            {
                _logger.LogError($"Not find entity by Id: {entity.Id} !");
            }

            await _userRepository.UpdateByIdAsync(entity.Id, entity, token);
        }

        public async Task DeleteByIdAsync(Guid id, CancellationToken token)
        {
            if (!await _userRepository.Exists(id))
            {
                _logger.LogError($"Not find entity by Id: {id} !");
            }

            await _userRepository.DeleteByIdAsync(id, token);   
        }
    }
}
