namespace EFCodeFirstSample.Domain.Entities
{
    /// <summary>
    /// Сотрудник.
    /// </summary>
    public class Employee : BaseEntitiy
    {
        /// <summary>
        /// Имя.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамиля.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Идентификатор отдела.
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Отдел.
        /// </summary>
        public Department? Department { get; set; }


        /// <summary>
        /// Зарплата.
        /// </summary>
        public decimal  Salary { get; set; }
    }
}
