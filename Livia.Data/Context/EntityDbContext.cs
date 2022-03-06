using Livia.Domain.Models.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Livia.Data.Context
{
    public class EntityDbContext : DbContext, IInternalDbContext
    {
        #region Ctor

        // services
        private readonly IHttpContextAccessor _httpContext;

        // per request cached objects

        public EntityDbContext(DbContextOptions<EntityDbContext> options, IHttpContextAccessor httpContext) : base(options)
        {
            _httpContext = httpContext;
        }

        #endregion Ctor

        #region SaveChanges Overrides

        /// <inheritdoc cref="DbContext"/>
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        /// <inheritdoc cref="DbContext"/>
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        /// <inheritdoc cref="DbContext"/>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        #endregion SaveChanges Overrides

        #region Utilities

        /// <inheritdoc cref="DbContext"/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        #endregion Utilities

        #region Methods

        /// <summary>
        /// Creates a DbSet that can be used to query and save instances of entity.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <returns>A set for the given entity type.</returns>
        public virtual new DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        /// <summary>
        /// Detach an entity from the context.
        /// </summary>
        /// <typeparam name="TEntity">Entity type.</typeparam>
        /// <param name="entity">Entity.</param>
        public virtual void Detach<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var entityEntry = Entry(entity);
            if (entityEntry == null)
                return;

            //set the entity is not being tracked by the context
            entityEntry.State = EntityState.Detached;
        }

        #endregion Methods
    }
}