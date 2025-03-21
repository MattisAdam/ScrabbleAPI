using Mattis.Core.Data.DbContexts;
using Mattis.Core.Data.Model;

namespace Mattis.Core.Data.Repository
{
    public interface IBaseRepository<TContext, TModelDao> where TModelDao : class, IModelDao where TContext : IBaseDbContext
    {
        TContext _context { get; }
        Task<IEnumerable<TModelDao>> GetAllAsync(bool withNoTracking = true);
        Task<TModelDao?> GetByIdAsync(int id, bool withNoTracking = true);
        Task AddAsync(TModelDao entity);
        Task AddAndSaveAsync(TModelDao entity);
        Task AddRangeAsync(IEnumerable<TModelDao> entities);
        Task UpdateAsync(TModelDao entity);
        void Delete(TModelDao? entity);
        Task DeleteAndSaveAsync(TModelDao? entity);
        Task DeleteAndSaveAsync(int id);
    }
}
