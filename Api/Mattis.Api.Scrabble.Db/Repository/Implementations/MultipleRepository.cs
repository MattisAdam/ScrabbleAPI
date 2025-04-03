using Mattis.Api.Scrabble.Db.DbContexts;
using Mattis.Api.Scrabble.Model;
using Mattis.Core.Data.Repository;

namespace Mattis.Api.Scrabble.Db.Repository.Implementations
{
    public class MultipleRepository : BaseRepository<IApiScrabbleDbContext, MultipleHistoryDao>, IMultipleRepository
    {
        public MultipleRepository(IApiScrabbleDbContext context) : base(context)
        {
        }
    }
}
