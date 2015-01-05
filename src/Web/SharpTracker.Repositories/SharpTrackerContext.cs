using SharpTracker.Entities;
using System.Data.Entity;

namespace SharpTracker.Repositories
{
	public class SharpTrackerContext : DbContext
	{
		public SharpTrackerContext()
			: base("SharpTrackerConnectionString")
		{
			
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Token> Tokens { get; set; }
		public DbSet<WorkingType> WorkingTypes { get; set; }
	}
}