using Data;
using System.Data.Entity;

namespace NewsSystem.App_Start
{
    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<NewsSiteDbContext, Data.Migrations.Configuration>());
            NewsSiteDbContext.Create().Database.Initialize(true);
        }
    }
}