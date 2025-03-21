using Mattis.Api.Scrabble.Db.DbContexts;
using Mattis.Api.Scrabble.Db.Repository;
using Mattis.Api.Scrabble.Db.Repository.Implementations;
using Mattis.Api.Scrabble.Db.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Mattis.Api.Scrabble.Db
{
    public static  class DbRegisterExtension
    {
        public static void RegisterScrabbleDbContainer(this IServiceCollection services)
        {
            services.AddScoped<IApiScrabbleUnitOfWork, ApiScrabbleUnitOfWork>();
            services.AddScoped<IApiScrabbleDbContext, ApiScrabbleDbContext>();
            services.AddScoped<IPlayerRepository, PlayerRepository>();
            services.AddScoped<IGameRepository, GameRepository>();
        }
    }
}
