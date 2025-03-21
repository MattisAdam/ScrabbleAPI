using Mattis.Api.Scrabble.Db.Repository;
using Mattis.Api.Scrabble.Db.DbContexts;

namespace Mattis.Api.Scrabble.Db.UnitOfWork
{
    public interface IApiScrabbleUnitOfWork
    {
        IApiScrabbleDbContext Context { get; }
        IPlayerRepository PlayerRepository { get; }
        IGameRepository GameRepository { get; }
        Task<int> SaveChangeAsync();
    }
}
