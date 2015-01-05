using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Xamarin.Forms;
using SharpTracker.Views;

namespace SharpTracker.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;
		private App _app { get; set;}

		public AppDelegate ()
		{
			_app = new App ();
			_app.Logout ();
		}

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			Forms.Init();

			window = new UIWindow(UIScreen.MainScreen.Bounds);

			window.RootViewController = new NavigationPage(new HomeView(_app)).CreateViewController();
			window.MakeKeyAndVisible();

			return true;
		}
	}
}

