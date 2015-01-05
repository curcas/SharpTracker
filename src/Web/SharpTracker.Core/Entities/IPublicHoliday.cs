using System;

namespace SharpTracker.Core.Entities
{
	public interface IPublicHoliday
	{
		int Id { get; set; }
		ILocation Location { get; set; }
		DateTime Date { get; set; }
		decimal Duration { get; set; }
	}
}