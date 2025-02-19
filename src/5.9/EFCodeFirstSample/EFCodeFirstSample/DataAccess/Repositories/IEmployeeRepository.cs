
using EFCodeFirstSample.Domain.Entities;
using EFCodeFirstSample.Specifications;
using System.Collections.Generic;

namespace EFCodeFirstSample.DataAccess.Repositories
{
    /// <summary>
    /// Репозиторий для работы с пользователями.
    /// </summary>
    public interface IEmployeeRepository
    {
        /// <summary>
        /// DjВозвращает все элементы коллекции.
        /// </summary>
        /// <param name="request">Запрос.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GetAll();

        /// <summary>
        ///  Возвращает все элементы по спецификации.
        /// </summary>
        /// <param name="specification">Спецификация./param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns></returns>
        Task<IEnumerable<Employee>> GetBySpecificationAsync(Specification<Employee> specification, CancellationToken cancellationToken);
     //   object GetAllBySpecification(Specification<Employee> specification);

        Task<Employee> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}