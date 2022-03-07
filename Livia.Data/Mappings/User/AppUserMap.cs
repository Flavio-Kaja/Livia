using Livia.Domain.Models.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livia.Data.Mappings.User
{
    public class AppUserMap : BaseEntityTypeConfiguration<AppUser>
    {
        public override int Order => 1;

        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(mapping => mapping.Username).IsRequired().HasMaxLength(30);
            base.Configure(builder);
        }
    }
}
