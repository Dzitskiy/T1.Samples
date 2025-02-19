namespace EFCodeFirstSample.Domain.Entities
{
    public class Department : BaseEntitiy
    {
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