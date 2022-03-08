using Livia.Domain.Models.Communication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livia.Data.Mappings.Communication
{
    public class ChannelMap : BaseEntityTypeConfiguration<Channel>
    {
        public override int Order => 1;

        public override void Configure(EntityTypeBuilder<Channel> builder)
        {
            builder.Property(mapping => mapping.Title).IsRequired().HasMaxLength(100);

            //Configure relationships
            builder.HasMany(mapping => mapping.Messages)
                .WithOne(message => message.Channel)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(mapping => mapping.Participants)
                .WithMany(user => user.Channels);

            builder.HasMany(mapping => mapping.Moderators)
                .WithMany(moderators => moderators.Channels);
            builder.MapAuditableEntity();
            base.Configure(builder);
        }
    }
}
