using FluentValidation;
using Livia.Data.Mappings.Schemas;
using Livia.Domain.Models.Task;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livia.Data.Mappings.Task
{
    using Task = Livia.Domain.Models.Task.Task;
    internal class TaskMap : BaseEntityTypeConfiguration<Task>
    {
        public override int Order => 1;

        public override void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.MapDefaults(Schema.Tasks);

            builder.Property(mapping => mapping.Title).IsRequired().HasMaxLength(50);
            builder.Property(mapping => mapping.Description).HasMaxLength(200);
            builder.MapAuditableEntity();

            base.Configure(builder);
        }

    }
}
