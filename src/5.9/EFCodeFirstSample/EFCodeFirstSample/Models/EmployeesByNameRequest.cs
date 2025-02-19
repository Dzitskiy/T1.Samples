namespace EFCodeFirstSample.Models
{
    /// <summary>
    /// Запрос на получение пользователей по имени.
    /// </summary>
    public class EmployeesByNameRequest
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; set; }
    }
}
