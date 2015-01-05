using System.ComponentModel.DataAnnotations;
using Foolproof;

namespace SharpTracker.Api.Areas.Version1.Models
{
	public class WorkingTypeModel
	{
		public int Id { get; set; }

		[Required]
		public string Name { get; set; }

		[Required]
		[NotEqualTo("IsFlexitime")]
		public bool IsHoliday { get; set; }

		[Required]
		[NotEqualTo("IsHoliday")]
		public bool IsFlexitime { get; set; }
	}
}