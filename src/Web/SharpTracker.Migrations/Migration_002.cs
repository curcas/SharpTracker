using System.Data.Entity.Migrations;

namespace SharpTracker.Migrations
{
	public class Migration_002 : DbMigration 
    {
		public override void Up()
		{
			CreateTable("Tokens",
				builder => new
				{
					Id = builder.Int(false, true, name: "Id"),
					User = builder.Int(false, name: "User"),
					Value = builder.String(false, 255, name: "Valuea"),
				})
				.PrimaryKey(x => x.Id)
				.Index(x => x.Value);

			AddForeignKey("Tokens", "User", "Users", "Id", true);
		}
    }
}
