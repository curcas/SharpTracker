using SharpTracker.Core.Entities;

namespace SharpTracker.Entities
{
	public class Location : ILocation
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public decimal Workhours { get; set; }
	}
}