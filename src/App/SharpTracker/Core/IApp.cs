using System;

namespace SharpTracker.Core
{
	public interface IApp
	{
		string GetToken();
		void OnLoginButtonClicked(string username, string password, Action callback);
		void Logout();
	}
}