using Livia.Domain.Models.Task;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Livia.Data.Mappings.Task
{
    public class CommentMap : BaseEntityTypeConfiguration<Comment>
    {
        public override int Order => 1;

        public override void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(mapping => mapping.Text).IsRequired().HasMaxLength(7000);
            builder.HasOne(mapping => mapping.Parent)
                .WithMany(comment => comment.Replies).IsRequired(false)
                .HasForeignKey(mapping => mapping.ParentId)
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
            base.Configure(builder);
        }
    }
}
