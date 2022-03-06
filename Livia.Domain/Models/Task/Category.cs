using Livia.Domain.Models.Base;

namespace Livia.Domain.Models.Task
{
    public class Category : AuditableEntity
    {
        public string Title { get; set; } = string.Empty;

        #region Referrential

        public ICollection<Task>? Tasks { get; set; }

        #endregion Referrential
    }
}