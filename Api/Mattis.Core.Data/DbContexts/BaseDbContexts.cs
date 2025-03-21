using Microsoft.EntityFrameworkCore;
using Mattis.Core.Data.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Mattis.Core.Data.DbContexts
{
    public class BaseDbContext : DbContext, IBaseDbContext
    {
        public BaseDbContext(DbContextOptions options) : base(options)
        {

        }


        public new EntityEntry<TModelDao> Entry<TModelDao>(TModelDao model) where TModelDao : class, IModelDao
        {
            return base.Entry<TModelDao>(model);
        }
    }
}
