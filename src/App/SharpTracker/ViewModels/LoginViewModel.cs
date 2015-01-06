using System.Collections.Generic;
using SharpTracker.Core.ViewModels;

namespace SharpTracker.ViewModels
{
	public class LoginViewModel : IViewModel
	{
		private IList<string> ValidationMessages { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }

		public LoginViewModel ()
		{
			ValidationMessages = new List<string> ();
		}

		public bool IsValid()
		{
			var valid = true;
			ValidationMessages.Clear();

			if (string.IsNullOrEmpty(Username))
			{
				valid = false;
				ValidationMessages.Add("Please enter a username!");
			}

			if (string.IsNullOrEmpty(Password))
			{
				valid = false;
				ValidationMessages.Add("Please enter a password!");
			}

			return valid;
		}

		public IList<string> GetValidationMessages()
		{
			return ValidationMessages;
		}

		public IDictionary<string, object> ToDictionary(){
			var x = new Dictionary<string, object> ();

			x.Add ("name", Username);
			x.Add ("password", Password);

			return x;
		}
	}
}