using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using SharpTracker.Views;
using System.ComponentModel.Design;
using SharpTracker.Core;
using Hjerpbakk.FermiContainer;


namespace SharpTracker.Android
{
	[Activity (Label = "SharpTracker.Android.Android", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : AndroidActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			Forms.Init(this, bundle);
			PrepareDependecyInjection ();

			SetPage(new NavigationPage(new HomeView()));
		}

		private void PrepareDependecyInjection(){
			FermiContainer.DefaultInstance.Register<IApp, App> ();
		}
	}
}

