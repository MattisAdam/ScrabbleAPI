using Mattis.Api.Scrabble.Model;
using Mattis.Core.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Mattis.Api.Scrabble.Db.DbContexts
{
    public class ApiScrabbleDbContext : BaseDbContext , IApiScrabbleDbContext
    {
        public ApiScrabbleDbContext(DbContextOptions<ApiScrabbleDbContext> options) : base(options)
        {
        }
        public DbSet<PlayerDao> PlayerDbSet { get; set; }
        public DbSet<MultipleHistoryDao> MultipleHistoryDbSet { get; set; }
    }
}
