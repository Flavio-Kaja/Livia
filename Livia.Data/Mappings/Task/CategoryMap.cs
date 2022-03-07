using Livia.Domain.Models.Task;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livia.Data.Mappings.Task
{
    public class CategoryMap : BaseEntityTypeConfiguration<Category>
    {
        public override int Order => 1;

        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(mapping => mapping.Title).IsRequired().HasMaxLength(100);
            builder.Property(mapping => mapping.De)
            base.Configure(builder);
        }

    }
}
