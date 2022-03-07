using Livia.Domain.Models.Base;

namespace Livia.Domain.Models.Communication
{
    public class Channel : AuditableEntity
    {
        public string Title { get; set; } = string.Empty;
    }
}
