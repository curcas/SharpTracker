using SharpTracker.Views;
using Xamarin.Forms;
using Hjerpbakk.FermiContainer;


namespace SharpTracker.Core.Views
{
	public class BaseContentPage : ContentPage
	{
		public readonly IApp App;

		protected BaseContentPage()
		{
			App = FermiContainer.DefaultInstance.Resolve<IApp> ();
		}

		public virtual void onLoad (){
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (!BasePage.IsLoggedIn (App.GetToken)) {
				Navigation.PushModalAsync (new LoginView (App.OnLoginButtonClicked, OnLoginFinished));
			} else {
				onLoad ();
			}
		}

		private void OnLoginFinished()
		{
			Navigation.PopModalAsync ();
			onLoad ();
		}
	}
}