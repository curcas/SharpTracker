using SharpTracker.Views;
using Xamarin.Forms;
using Hjerpbakk.FermiContainer;


namespace SharpTracker.Core.Views
{
	public class BaseContentPage : ContentPage
	{
		private readonly IApp _app;

		protected BaseContentPage()
		{
			_app = FermiContainer.DefaultInstance.Resolve<IApp> ();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (!BasePage.IsLoggedIn(_app.GetToken))
			{
				Navigation.PushModalAsync(new LoginView(_app.OnLoginButtonClicked));
			}
		}

		private void OnLoginFinished()
		{
			Navigation.PopAsync();
		}
	}
}