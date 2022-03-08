using Livia.Domain.Models.Communication;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livia.Data.Mappings.Communication
{
    public class MessageMap : BaseEntityTypeConfiguration<Message>
    {
        public override int Order => 1;

        public override void Configure(EntityTypeBuilder<Message> builder)
        {
            builder.Property(mapping => mapping.Text).IsRequired().HasMaxLength(5000);

            builder.HasOne(mapping => mapping.Sender);
            builder.HasMany(mapping => mapping.Receivers);
            base.Configure(builder);
        }

    }
}
