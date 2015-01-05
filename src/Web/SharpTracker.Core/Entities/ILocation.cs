namespace SharpTracker.Core.Entities
{
	public interface ILocation
	{
		int Id { get; set; }
		string Name { get; set; }
		decimal Workhours { get; set; }
	}
}