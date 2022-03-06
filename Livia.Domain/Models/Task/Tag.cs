using Livia.Domain.Models.Base;

namespace Livia.Domain.Models.Task
{
    public class Tag : AuditableEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        #region Referrential

        public virtual ICollection<Task>? Tasks { get; set; } = null;

        #endregion Referrential
    }
}