using Livia.Domain.Models.Base;
using Livia.Domain.Models.User;

namespace Livia.Domain.Models.Communication
{
    public class Channel : AuditableEntity
    {
        public string Title { get; set; } = string.Empty;

        #region Referential
        public virtual ICollection<Message>? Messages { get; set; }
        public virtual ICollection<AppUser> Participants { get; set; } = default!;
        public virtual ICollection<AppUser> Moderators { get; set; } = default!;

        #endregion Referential
    }
}
