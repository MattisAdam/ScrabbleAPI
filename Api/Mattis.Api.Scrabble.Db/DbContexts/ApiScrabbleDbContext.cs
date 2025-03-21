using Mattis.Api.Scrabble.Model;
using Mattis.Core.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Mattis.Api.Scrabble.Db.DbContexts
{
    internal class ApiScrabbleDbContext : BaseDbContext , IApiScrabbleDbContext
    {
        public ApiScrabbleDbContext(DbContextOptions<ApiScrabbleDbContext> options) : base(options)
        {
        }
        public DbSet<PlayerDao> PlayerDbSet { get; set; }
    }
}
