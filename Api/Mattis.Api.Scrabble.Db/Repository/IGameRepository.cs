using Mattis.Api.Scrabble.Db.DbContexts;
using Mattis.Api.Scrabble.Model;
using Mattis.Core.Data.Repository;

namespace Mattis.Api.Scrabble.Db.Repository
{
    public interface IGameRepository  : IBaseRepository<IApiScrabbleDbContext, GameDao>
    {
    }
}
