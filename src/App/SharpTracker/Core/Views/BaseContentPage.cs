using SharpTracker.Views;
using Xamarin.Forms;

namespace SharpTracker.Core.Views
{
	public class BaseContentPage : ContentPage
	{
		private readonly IApp _app;

		protected BaseContentPage(IApp app)
		{
			_app = app;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			if (!BasePage.IsLoggedIn(_app.GetToken))
			{
				Navigation.PushModalAsync(new LoginView(_app.OnLoginButtonClicked));
				//Navigation.PushAsync(new Login(_app.OnLoginButtonClicked, OnLoginFinished));
			}
		}

		private void OnLoginFinished()
		{
			Navigation.PopAsync();
		}
	}
}