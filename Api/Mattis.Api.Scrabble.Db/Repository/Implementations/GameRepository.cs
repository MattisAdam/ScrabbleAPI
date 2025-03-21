using Mattis.Api.Scrabble.Db.DbContexts;
using Mattis.Api.Scrabble.Model;
using Mattis.Core.Data.Repository;

namespace Mattis.Api.Scrabble.Db.Repository.Implementations
{
    public class GameRepository : BaseRepository<IApiScrabbleDbContext, GameDao>, IGameRepository
    {
        public GameRepository(IApiScrabbleDbContext context) : base(context)
        {
        }
    }
}
