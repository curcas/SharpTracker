using System;
using SharpTracker.ViewModels;
using Xamarin.Forms;

namespace SharpTracker.Views
{
	public class LoginView : ContentPage
	{
		private static bool _isLoginButtonOngoing;
		private static Action<string, string, Action> _loginButtonAction;
		private LoginViewModel _loginViewModel;

		private Entry UsernameEntry { get; set;}
		private Entry PasswordEntry { get; set;}

		private LoginViewModel Model
		{
			get { return _loginViewModel ?? (_loginViewModel = new LoginViewModel()); }
		}

		public LoginView(Action<string, string, Action> loginButtonAction)
		{
			BindingContext = Model;

			_loginButtonAction = loginButtonAction;

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

		private void OnLoginClicked(object sender, EventArgs e)
		{
			if (_loginViewModel.IsValid())
			{
				if (!_isLoginButtonOngoing)
				{
					_isLoginButtonOngoing = true;

					var action = _loginButtonAction;
					if (action != null)
					{
						action.Invoke(UsernameEntry.Text, PasswordEntry.Text, () => Navigation.PopModalAsync());
					}

					_isLoginButtonOngoing = false;
				}
			}
			else
			{
				DisplayAlert("Error", string.Join(Environment.NewLine, _loginViewModel.GetValidationMessages()), "OK", null);
			}
		}
	}
}




















/*using System;
using Xamarin.Forms;

namespace SharpTracker
{
	public class LoginPage : ContentPage
	{
		private static bool _isLoginButtonOngoing;
		private static Action<string, string, Action> _loginButtonAction;
		private static Action _callback;

		private static readonly Entry NameField = new Entry
		{
			Placeholder = "Username"
		};

		private static readonly Entry PasswordField = new Entry
		{
			IsPassword = true,
			Placeholder = "Password"
		};

		private static readonly Button LoginButton = new Button
		{
			Text = "Login",
			TextColor = Color.White,
			BackgroundColor = Color.FromHex("77D065")
		};

		public LoginPage(Action<string, string, Action> loginButtonAction, Action callback)
		{
			_loginButtonAction = loginButtonAction;
			_callback = callback;
			LoginButton.Clicked += LoginButtonOnClicked;

			Content = new StackLayout
			{
				Spacing = 20,
				Padding = 50,
				VerticalOptions = LayoutOptions.Center,
				Children =
					{
						NameField,
						PasswordField,
						LoginButton
					}
			};
		}

		private static void LoginButtonOnClicked(object sender, EventArgs eventArgs)
		{
			if (!_isLoginButtonOngoing)
			{
				_isLoginButtonOngoing = true;

				var action = _loginButtonAction;
				if (action != null)
				{
					action.Invoke(NameField.Text, PasswordField.Text, _callback);
				}

				_isLoginButtonOngoing = false;
			}
		}
	}
}*/