using System;
using SharpTracker.Core;
using MonoTouch.Foundation;
using SharpTracker.Models;

namespace SharpTracker.iOS
{
	public class App : IApp
	{
		public string GetToken()
		{
			return NSUserDefaults.StandardUserDefaults.StringForKey ("LoginToken");
		}

		public async void OnLoginButtonClicked(LoginModel model, Action callback)
		{
			if (!string.IsNullOrEmpty(model.Token))
			{
				NSUserDefaults.StandardUserDefaults.SetString (model.Token, "LoginToken");
				callback.Invoke();
			}
		}

		public void Logout()
		{
			NSUserDefaults.StandardUserDefaults.SetString (string.Empty, "LoginToken");
		}
	}
}