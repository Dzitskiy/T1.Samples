using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFCodeFirstSample.Domain.Entities
{
    public class Department : BaseEntitiy
    {
        /**/
        private ILazyLoader _lazyLoader;
        private ICollection<Employee> _employees;

        public Department(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        public ICollection<Employee> Employees
        {
            get => _lazyLoader.Load(this, ref _employees);
            set => _employees = value;
        }

        /**/

        /// <summary>
        /// Название отдела.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Список сотрудников.
        /// </summary>
        //public /*virtual*/ ICollection<Employee> Employees { get; set; }
    }
}