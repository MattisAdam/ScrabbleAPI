using Mattis.Api.Scrabble.Db.DbContexts;
using Mattis.Api.Scrabble.Db.Repository;

namespace Mattis.Api.Scrabble.Db.UnitOfWork
{
    internal class ApiScrabbleUnitOfWork : IApiScrabbleUnitOfWork
    {
        public IApiScrabbleDbContext Context { get; }
        public IPlayerRepository PlayerRepository { get; }
        public IGameRepository GameRepository { get; }
        public IMultipleRepository MultipleRepository { get; }


        public ApiScrabbleUnitOfWork(
            IApiScrabbleDbContext context, 
            IPlayerRepository playerRepository, 
            IGameRepository gameRepository, 
            IMultipleRepository multipleRepository)
        {
            Context = context;
            PlayerRepository = playerRepository;
            GameRepository = gameRepository;
            MultipleRepository = multipleRepository;
        }

        public async Task<int> SaveChangeAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
