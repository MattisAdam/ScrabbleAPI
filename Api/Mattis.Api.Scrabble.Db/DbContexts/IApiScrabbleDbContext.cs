using Mattis.Api.Scrabble.Model;
using Mattis.Core.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Mattis.Api.Scrabble.Db.DbContexts
{
    public interface IApiScrabbleDbContext : IBaseDbContext
    {
        public DbSet<PlayerDao> PlayerDbSet { get; set; }
        public DbSet<MultipleHistoryDao> MultipleHistoryDbSet { get; set; }
    }
}
