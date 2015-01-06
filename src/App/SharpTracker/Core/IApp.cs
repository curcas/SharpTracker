using System;
using SharpTracker.Models;

namespace SharpTracker.Core
{
	public interface IApp
	{
		string GetToken();
		void OnLoginButtonClicked(LoginModel model, Action callback);
		void Logout();
	}
}