using Mattis.Api.Scrabble.Db.DbContexts;
using Mattis.Api.Scrabble.Dto;
using Mattis.Api.Scrabble.Model;
using Mattis.Core.Data.Repository;

namespace Mattis.Api.Scrabble.Db.Repository
{
    public interface IPlayerRepository : IBaseRepository<IApiScrabbleDbContext, PlayerDao>
    {
        Task<IEnumerable<PlayerDao>?> GetByCriteriaAsync(PlayerCriteria criteria);
    }
}