using Livia.Domain.Models.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livia.Data.Mappings.User
{
    internal class PersonMap : BaseEntityTypeConfiguration<Person>
    {
        public override int Order => 1;

        public override void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(mapping => mapping.FirstName).IsRequired().HasMaxLength(20);
            builder.Property(mapping => mapping.LastName).IsRequired().HasMaxLength(20);
            builder.Property(mapping => mapping.BirthDate).IsRequired();
            builder.MapAuditableEntity();
            base.Configure(builder);
        }
    }
}
