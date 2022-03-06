using Livia.Domain.Models.User;

namespace Livia.Domain.Models.Base
{
    /// <summary>
    /// Interface to track audit data.
    /// </summary>
    public interface IAuditableEntity
    {
        /// <summary>
        /// Gets or sets the date this entity was first created. Cannot be null.
        /// </summary>
        DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the username of the user that created this entity.
        /// </summary>
        string? CreatedByUsername { get; set; }

        /// <summary>
        /// Gets or sets the Id of the user that created this entity.
        /// </summary>
        Guid? CreatedById { get; set; }

        /// <summary>
        /// Gets or sets the createdBy user
        /// </summary>
        Person CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the date this entity was last updated.
        /// </summary>
        DateTime? UpdatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the username of the user that last updated this entity.
        /// </summary>
        string? UpdatedByUsername { get; set; }

        /// <summary>
        /// Gets or sets the Id of the user that updated this entity.
        /// </summary>
        Guid? UpdatedById { get; set; }

        /// <summary>
        /// Gets or sets the updatedBy user
        /// </summary>
        Person? UpdatedBy { get; set; }
    }
}