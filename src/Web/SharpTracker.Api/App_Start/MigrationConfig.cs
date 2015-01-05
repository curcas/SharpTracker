using SharpTracker.Repositories;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace SharpTracker.Api
{
	public class MigrationConfig
	{
		public static void SetInitializer()
		{
			Database.SetInitializer(new MigrateDatabaseToLatestVersion<SharpTrackerContext, Configuration>());

			var configuration = new Configuration();
			var migrator = new DbMigrator(configuration);
			migrator.Update();
		}
	}

	internal sealed class Configuration : DbMigrationsConfiguration<SharpTrackerContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = true;
		}
	}
}
