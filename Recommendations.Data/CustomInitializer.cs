using Recommendations.Data.Migrations;
using System.Data.Entity;

namespace Recommendations.Data
{
    public class CustomInitializer : MigrateDatabaseToLatestVersion<DataContext, Configuration>
    {
        public override void InitializeDatabase(DataContext context)
        {
            base.InitializeDatabase(context);
        }
    }
}