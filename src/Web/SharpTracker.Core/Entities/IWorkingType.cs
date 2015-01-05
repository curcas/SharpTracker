namespace SharpTracker.Core.Entities
{
	public interface IWorkingType
	{
		int Id { get; set; }
		string Name { get; set; }
		bool IsHoliday { get; set; }
		bool IsFlexitime { get; set; }
	}
}