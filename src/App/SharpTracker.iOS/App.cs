using System;
using SharpTracker.Core;
using MonoTouch.Foundation;

namespace SharpTracker.iOS
{
	public class App : IApp
	{
		public string GetToken()
		{
			return NSUserDefaults.StandardUserDefaults.StringForKey ("LoginToken");
		}

		public async void OnLoginButtonClicked(string username, string password, Action callback)
		{
			var controller = new LoginController();
			var result = await controller.DoLogin(username, password);

			if (!string.IsNullOrEmpty(result.Token))
			{
				NSUserDefaults.StandardUserDefaults.SetString (result.Token, "LoginToken");
				callback.Invoke();
			}
		}

		public void Logout()
		{
			NSUserDefaults.StandardUserDefaults.SetString (string.Empty, "LoginToken");
		}
	}
}