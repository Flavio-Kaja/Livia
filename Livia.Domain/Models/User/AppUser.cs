using Livia.Domain.Models.Base;

namespace Livia.Domain.Models.User
{
    public class AppUser : AuditableEntity
    {
        public override int Id => PersonId;
        public int PersonId { get; set; }
        public string Username { get; set; } = string.Empty;

        #region Referential
        public virtual Person Person { get; set; } = default!;
        #endregion Referential

    }
}
