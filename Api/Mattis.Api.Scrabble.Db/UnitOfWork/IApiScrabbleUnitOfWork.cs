using Mattis.Api.Scrabble.Db.Repository;
using Mattis.Api.Scrabble.Db.DbContexts;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mattis.Api.Scrabble.Db.UnitOfWork
{
    public interface IApiScrabbleUnitOfWork
    {
        IApiScrabbleDbContext Context { get; }
        IPlayerRepository PlayerRepository { get; }
        IGameRepository GameRepository { get; }
        IMultipleRepository MultipleRepository { get; }
        Task<int> SaveChangeAsync();
    }
}
