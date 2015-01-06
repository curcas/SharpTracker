using System;

namespace SharpTracker.Core.Views
{
	public class BasePage
	{
		public static bool IsLoggedIn(Func<string> getTokenFunc)
		{
			return !string.IsNullOrEmpty(getTokenFunc.Invoke());
		} 
	}
}