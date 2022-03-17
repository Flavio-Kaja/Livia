using Livia.Data.Mappings;
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

        #region sets
        public DbSet<Domain.Models.Task.Task> Tasks { get; set; }
        public DbSet<Domain.Models.Task.Tag> Tags { get; set; }
        public DbSet<Domain.Models.Task.Category> Categories { get; set; }
        public DbSet<Domain.Models.Task.Comment> Comments { get; set; }
        public DbSet<Domain.Models.Communication.Channel> Channels { get; set; }
        public DbSet<Domain.Models.Communication.Message> Messages { get; set; }
        public DbSet<Domain.Models.Communication.Notification> Notifications { get; set; }
        public DbSet<Domain.Models.User.AppUser> AppUsers { get; set; }
        public DbSet<Domain.Models.User.Person> Persons { get; set; }
        #endregion sets

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

        /// <inheritdoc cref="DbContext"/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //dynamically load all entity and query type configurations
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var typeConfigurations = assemblies.SelectMany(a => a.GetTypes()).Where(type =>
                (type.BaseType?.IsGenericType ?? false)
                && type.BaseType.GetGenericTypeDefinition() == typeof(BaseEntityTypeConfiguration<>));

            var mapList = new List<IMappingConfiguration?>();
            foreach (var typeConfiguration in typeConfigurations)
            {
                var configuration = Activator.CreateInstance(typeConfiguration) as IMappingConfiguration;
                mapList.Add(configuration);
            }
            foreach (var map in mapList.OrderBy(l => l?.Order))
            {
                map?.ApplyConfiguration(modelBuilder);
            }

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