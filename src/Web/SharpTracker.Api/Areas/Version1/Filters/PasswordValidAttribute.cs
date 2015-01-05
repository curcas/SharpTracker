using System.ComponentModel.DataAnnotations;
using Ninject;
using SharpTracker.Core.Repositories;

namespace SharpTracker.Api.Areas.Version1.Filters
{
	public class PasswordValidAttribute : ValidationAttribute
	{
		private readonly string _userNamePropertyName;

		[Inject]
		public IUserRepository UserRepository { get; set; }

		public PasswordValidAttribute(string userNamePropertyName)
		{
			_userNamePropertyName = userNamePropertyName;
		}

		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var userName = GetUserName(validationContext);

			if (string.IsNullOrEmpty(userName))
			{
				return new ValidationResult("In order to validate the password a username is required.");
			}

			if(string.IsNullOrEmpty((string)value))
			{
				return new ValidationResult("Password is not set.");
			}

			var user = UserRepository.Get(userName);

			if (user == null)
			{
				return new ValidationResult("User does not exist.");
			}

			if (user.Password != (string) value)
			{
				return new ValidationResult("Password is incorrect.");
			}

			return null;
		}

		protected virtual string GetUserName(ValidationContext validationContext)
		{
			var userNameProperty = validationContext.ObjectType.GetProperty(_userNamePropertyName);
			return (string) userNameProperty.GetValue(validationContext.ObjectInstance);
		}
	}
}