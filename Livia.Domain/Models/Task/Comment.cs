using Livia.Domain.Models.Base;

namespace Livia.Domain.Models.Task
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; } = string.Empty;
        public DateTime CreatedOnUtc { get; set; }
        public int? ParentId { get; set; }

        #region Referential
        public virtual Comment? Parent { get; set; }
        public virtual ICollection<Comment>? Replies { get; set; }
        #endregion Referential
    }
}
