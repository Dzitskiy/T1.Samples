using Microsoft.EntityFrameworkCore.Infrastructure;

namespace EFCodeFirstSample.Domain.Entities
{
    public class Department : BaseEntitiy
    {
        private ICollection<Employee> _employees;   

        public Department()
        {
        }

        /// <summary>
        /// Название отдела.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Список сотрудников.
        /// </summary>
        public ICollection<Employee> Employees { get; set; }
        }
}