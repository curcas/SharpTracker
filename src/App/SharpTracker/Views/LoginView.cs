using System;
using SharpTracker.ViewModels;
using Xamarin.Forms;
using SharpTracker.Models;
using SharpTracker.Core.Views;

namespace SharpTracker.Views
{
	public class LoginView : ContentPage
	{
		private static bool _isLoginButtonOngoing;
		private static Action<LoginModel, Action> _loginButtonAction;
		private LoginViewModel _loginViewModel;
		private Action _onLoginFinished;

		private Entry UsernameEntry { get; set;}
		private Entry PasswordEntry { get; set;}

		private LoginViewModel Model
		{
			get { return _loginViewModel ?? (_loginViewModel = new LoginViewModel()); }
		}

		public LoginView(Action<LoginModel, Action> loginButtonAction, Action onLoginFinished)
		{
			BindingContext = Model;

			_loginButtonAction = loginButtonAction;
			_onLoginFinished = onLoginFinished;

			UsernameEntry = new Entry { Placeholder = "Username" };
			UsernameEntry.SetBinding(Entry.TextProperty, "Username");

			PasswordEntry = new Entry { IsPassword = true, Placeholder = "Password" };
			PasswordEntry.SetBinding(Entry.TextProperty, "Password");

			var loginButton = new Button { Text = "Login", TextColor = Color.White, BackgroundColor = Color.FromHex("77D065") };
			loginButton.Clicked += OnLoginClicked;

			Content = new StackLayout
			{
				Spacing = 20,
				Padding = 50,
				VerticalOptions = LayoutOptions.Center,
				Children =
					{
						UsernameEntry,
						PasswordEntry,
						loginButton
					}
			};
		}

		private async void OnLoginClicked(object sender, EventArgs e)
		{
			if (_loginViewModel.IsValid())
			{
				if (!_isLoginButtonOngoing)
				{
					_isLoginButtonOngoing = true;

					var action = _loginButtonAction;
					if (action != null)
					{
						var loginModel = await Request<LoginModel>.Post("/login", _loginViewModel.ToDictionary());
						action.Invoke(loginModel, _onLoginFinished);
					}

					_isLoginButtonOngoing = false;
				}
			}
			else
			{
				await DisplayAlert("Error", string.Join(Environment.NewLine, _loginViewModel.GetValidationMessages()), "OK");
			}
		}
	}
}
