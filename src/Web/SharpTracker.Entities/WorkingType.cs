using SharpTracker.Core.Entities;

namespace SharpTracker.Entities
{
	public class WorkingType : IWorkingType
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool IsHoliday { get; set; }
		public bool IsFlexitime { get; set; }
	}
}