using Mattis.Api.Scrabble.Db.DbContexts;
using Mattis.Api.Scrabble.Dto;
using Mattis.Api.Scrabble.Model;
using Mattis.Core.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace Mattis.Api.Scrabble.Db.Repository.Implementations
{
    public class PlayerRepository : BaseRepository<IApiScrabbleDbContext, PlayerDao>, IPlayerRepository
    {
        public PlayerRepository(IApiScrabbleDbContext context) : base(context) { }

        public async Task<IEnumerable<PlayerDao>?> GetByCriteriaAsync(PlayerCriteria criteria)
        {
            var query = _context.PlayerDbSet.AsNoTracking();

            if (criteria.IsActive.HasValue)
                query = query.Where(x => x.IsActive == criteria.IsActive.Value);

            if (!string.IsNullOrWhiteSpace(criteria.FilterText))
                query = query.Where(x => x.Pseudo.Contains(criteria.FilterText));
            if(criteria.MaxAge > 0)
            {
                var thisYear = DateTime.Now.Year;
                query = query.Where(x =>(thisYear - x.Birthdate.Year) <= criteria.MaxAge);
            }

            return await query.ToListAsync();
        }
    }
}