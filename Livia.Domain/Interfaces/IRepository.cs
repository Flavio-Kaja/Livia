using Livia.Domain.Models.Base;

namespace Livia.Domain.Interfaces
{
    /// <summary>
    /// Interface of base repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        bool AutoSaveChanges { get; set; }
        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }

        void Delete(TEntity entity);

        void Delete(IEnumerable<TEntity> entities);

        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task DeleteAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        void Insert(TEntity entity);

        void Insert(IEnumerable<TEntity> entities);

        Task InsertAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task InsertAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);

        void Update(TEntity entity);

        void Update(IEnumerable<TEntity> entities);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task UpdateAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }
}