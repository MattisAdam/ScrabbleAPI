using Microsoft.EntityFrameworkCore.ChangeTracking;
using Mattis.Core.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Mattis.Core.Data.DbContexts
{
    public interface IBaseDbContext
    {
        EntityEntry<TModelDao> Entry<TModelDao>(TModelDao entry) where TModelDao : class, IModelDao;
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSucces = true, CancellationToken cancellationToken = new CancellationToken());
    }
}
