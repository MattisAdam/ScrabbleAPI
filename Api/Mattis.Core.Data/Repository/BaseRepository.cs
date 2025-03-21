using Mattis.Core.Data.DbContexts;
using Mattis.Core.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Mattis.Core.Data.Repository
{
    public class BaseRepository<TContext, TModelDao> : IBaseRepository<TContext, TModelDao> where TModelDao : class, IModelDao where TContext : IBaseDbContext
    {

        public TContext _context { get; }


        public BaseRepository(TContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TModelDao>> GetAllAsync (bool withNoTracking = true)
        {
            IQueryable<TModelDao> query = _context.Set<TModelDao>();

            if(withNoTracking)
            {
                query = query.AsNoTracking();
            }
            return await query.ToListAsync();
        }

        public async Task<TModelDao?> GetByIdAsync(int id, bool withNoTracking = true)
        {
            IQueryable<TModelDao> query = _context.Set<TModelDao>();


            if (withNoTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task AddAsync(TModelDao entity)
        {
            await _context.Set<TModelDao>().AddAsync(entity);
        }
        public async Task AddAndSaveAsync(TModelDao entity)
        {
            await _context.Set<TModelDao>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task AddRangeAsync(IEnumerable<TModelDao> entities)
        {
            await _context.Set<TModelDao>().AddRangeAsync(entities);
        }


        public async Task UpdateAsync (TModelDao entity)
        {
            _context.Set<TModelDao>().Attach(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(TModelDao? entity)
        {
            if(entity != null)
            {
                _context.Set<TModelDao>().Remove(entity);
            }
        }

        public async Task DeleteAndSaveAsync(TModelDao? entity) 
        {
            if(entity != null)
            {
                _context.Set<TModelDao>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteAndSaveAsync(int id) 
        {
            var entity = await _context.Set<TModelDao>().FindAsync(id);
            await DeleteAndSaveAsync(entity);
        }

    }
}
