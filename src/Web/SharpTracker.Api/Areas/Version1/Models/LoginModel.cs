using System.ComponentModel.DataAnnotations;
using SharpTracker.Api.Areas.Version1.Filters;

namespace SharpTracker.Api.Areas.Version1.Models
{
	public class LoginModel
	{
		[Required]
		[UserExists]
		public string Name { get; set; }

		[Required]
		[PasswordValid("Name")]
		public string Password { get; set; }
	}
}
