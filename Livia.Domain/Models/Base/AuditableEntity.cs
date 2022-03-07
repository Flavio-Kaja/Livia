using Livia.Domain.Models.User;
using System.ComponentModel.DataAnnotations;

namespace Livia.Domain.Models.Base
{
    public class AuditableEntity : BaseEntity, IAuditableEntity
    {
        /// <inheritdoc />
        public DateTime CreatedOnUtc { get; set; }

        /// <inheritdoc />
        [MaxLength(100)]
        public string? CreatedByUsername { get; set; }

        /// <inheritdoc />
        public Guid? CreatedById { get; set; }

        /// <inheritdoc />
        public virtual Person CreatedBy { get; set; } = default!;

        /// <inheritdoc />
        public DateTime? UpdatedOnUtc { get; set; }

        /// <inheritdoc />
        [MaxLength(100)]
        public string? UpdatedByUsername { get; set; }

        /// <inheritdoc />
        public Guid? UpdatedById { get; set; }

        public virtual Person? UpdatedBy { get; set; }
    }
}