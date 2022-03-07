using Livia.Domain.Models.Task;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livia.Data.Mappings.Task
{
    public class TagMap : BaseEntityTypeConfiguration<Tag>
    {
        public override int Order => 1;

        public override void Configure(EntityTypeBuilder<Tag> builder)
        {

            builder.Property(mapping => mapping.Title).IsRequired().HasMaxLength(50);
            builder.MapAuditableEntity();
            base.Configure(builder);
        }
    }
}
