using Livia.Domain.Models.Base;
using Livia.Domain.Models.User;

namespace Livia.Domain.Models.Communication
{
    public class Message : BaseEntity
    {
        public string Text { get; set; } = string.Empty;
        public DateTime CreatedOnUtc { get; set; }

        #region Referential
        public virtual Person Sender { get; set; } = default!;
        public virtual Channel Channel { get; set; } = default!;
        public virtual ICollection<Person>? Receivers { get; set; }

        //TODO : maybe add a status feature to see who has read what option
        #endregion
    }
}
