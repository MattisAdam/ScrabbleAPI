using Mattis.Api.Scrabble.Db.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mattis.Api.Scrabble.Db
{
    public static class DbConfigurationExtension
    {
        public static void AddApiScrabbleDbContext(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ApiScrabbleDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MattisScrabbleDb"),
                o =>
                {
                    o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery).UseRelationalNulls();
                    o.CommandTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                }));
        }
    }
}
