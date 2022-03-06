﻿using Livia.Domain.Models.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livia.Data.Mappings
{
    public static class MappingExtensions
    {
        /// <summary>
        /// Maps the Id field of the BaseEntity to the PK of the table.
        /// </summary>
        /// <typeparam name="TEntity">Entity to configure.</typeparam>
        /// <param name="builder">Model builder.</param>
        public static void HasKeyDefault<TEntity>(this EntityTypeBuilder<TEntity> builder) where TEntity : BaseEntity
        {
            builder.HasKey(model => model.Id);
            builder.Property(model => model.Id).HasDefaultValueSql("newsequentialid()");
        }

        /// <summary>
        /// Maps the entity to a default Table name, which is the entity name.
        /// </summary>
        /// <typeparam name="TEntity">Entity to configure.</typeparam>
        /// <param name="builder">Model builder.</param>
        /// <param name="schema">Schema of the entity.</param>
        public static void ToTableDefault<TEntity>(this EntityTypeBuilder<TEntity> builder, string? schema = null) where TEntity : BaseEntity
        {
            ((EntityTypeBuilder)builder).ToTable(typeof(TEntity).Name, schema);
        }

        /// <summary>
        /// Maps the entity to a default table, with a default PK.
        /// Guest table name is entity type name,
        /// and default PK is <see cref="BaseEntity" />.Id with a default value of: <c>newsequentialid()</c>.
        /// </summary>
        /// <typeparam name="TEntity">Entity to configure.</typeparam>
        /// <param name="builder">Model builder.</param>
        /// <param name="schema">Schema of the entity.</param>
        public static void MapDefaults<TEntity>(this EntityTypeBuilder<TEntity> builder, string? schema = null) where TEntity : BaseEntity
        {
            builder.ToTableDefault(schema);
            builder.HasKeyDefault();
        }

        /// <summary>
        /// Maps the default IAudit information.
        /// </summary>
        /// <typeparam name="TEntity">Entity to configure.</typeparam>
        /// <param name="builder">Model builder.</param>
        public static void MapAuditableEntity<TEntity>(this EntityTypeBuilder<TEntity> builder)
            where TEntity : AuditableEntity
        {
            builder.Property(mapping => mapping.CreatedOnUtc).IsRequired();

            builder.HasOne(model => model.CreatedBy)
                .WithMany()
                .HasForeignKey(model => model.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(model => model.UpdatedBy)
                .WithMany()
                .HasForeignKey(model => model.UpdatedById)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}