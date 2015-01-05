using System.ComponentModel.DataAnnotations;
using Ninject;
using SharpTracker.Core.Repositories;

namespace SharpTracker.Api.Areas.Version1.Filters
{
	public class UserExistsAttribute : ValidationAttribute
	{
		[Inject]
		public IUserRepository UserRepository { get; set; }

		public override bool IsValid(object value)
		{
			if (!(value is string) || string.IsNullOrEmpty((string) value))
			{
				return false;
			}

			return UserRepository.Get((string) value) != null;
		}
	}
}