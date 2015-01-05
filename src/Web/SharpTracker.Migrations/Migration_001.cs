using System.Data.Entity.Migrations;

namespace SharpTracker.Migrations
{
	public class Migration_001 : DbMigration 
    {
		public override void Up()
		{
			CreateTable("Users",
				builder => new
				{
					Id = builder.Int(false, true, name: "Id"),
					Name = builder.String(false, 255, name: "Name"),
					Password = builder.String(false, 255, name: "Password"),
					Salt = builder.String(false, 10, name: "Salt")
				})
				.PrimaryKey(x => x.Id)
				.Index(x => x.Name);
		}
    }
}
