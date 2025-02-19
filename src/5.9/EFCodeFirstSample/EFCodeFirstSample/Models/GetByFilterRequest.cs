namespace EFCodeFirstSample.Models
{
    public class GetByFilterRequest
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        public string? FirstName { get; set; }
        /// <summary>
        /// Фамиля.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Идентификатор отдела.
        /// </summary>
        public string?  DepartmentName { get; set; }
    }
}
