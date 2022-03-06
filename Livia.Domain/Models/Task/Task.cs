using Livia.Domain.Models.Base;
using Livia.Domain.Models.User;

namespace Livia.Domain.Models.Task
{
    public class Task : AuditableEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Deadline { get; set; }
        public int? CategoryId { get; set; }

        #region Referrential

        public ICollection<Person>? AssignedTo { get; set; }
        public virtual ICollection<Tag>? Tags { get; set; }
        public Category? Category { get; set; }

        #endregion Referrential
    }
}