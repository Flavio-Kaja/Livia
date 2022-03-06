using Livia.Domain.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace Livia.Data.Context
{
    public interface IDbContext
    {
        void Detach<TEntity>(TEntity entity) where TEntity : BaseEntity;

        int SaveChanges();

        int SaveChanges(bool acceptAllChangesOnSuccess);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);

        DbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
    }
}