using Livia.Domain.Models.Base;
using Livia.Domain.Models.User;

namespace Livia.Domain.Models.Communication
{
    public class Notification : BaseEntity
    {
        public string Text { get; set; } = string.Empty;
        public DateTime TimeSended { get; set; }

        #region Referential
        public ICollection<AppUser> Receivers { get; set; } = default!;
        #endregion


    }
}
