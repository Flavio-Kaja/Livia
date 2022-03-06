using Livia.Domain.Models.Base;

namespace Livia.Domain.Models.User
{
    /// <summary>
    /// Class representing the person properties of a user
    /// </summary>
    public class Person : AuditableEntity
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}