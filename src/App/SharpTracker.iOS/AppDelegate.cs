using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Xamarin.Forms;
using SharpTracker.Views;
using Hjerpbakk.FermiContainer;
using SharpTracker.Core;

namespace SharpTracker.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		UIWindow window;

		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			PrepareDependecyInjection ();
			Forms.Init();

			window = new UIWindow(UIScreen.MainScreen.Bounds);

			window.RootViewController = new NavigationPage(new HomeView()).CreateViewController();
			window.MakeKeyAndVisible();

			return true;
		}

		private void PrepareDependecyInjection(){
			FermiContainer.DefaultInstance.Register<IApp, App> ();
		}

	}
}

