namespace Domain
{
    /// <summary>
    /// Сущность Пользователь.
    /// </summary>
    public class User : BaseEntity
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Email.
        /// </summary>
        public string Email { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
