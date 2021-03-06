﻿using System;
using Android.App;
using Android.Content;
using SharpTracker.Core;
using SharpTracker.Models;

namespace SharpTracker.Android
{
	public class App : IApp
	{
		public string GetToken()
		{
			var preferences = Application.Context.GetSharedPreferences("UserData", FileCreationMode.Private);
			return preferences.GetString("Token", string.Empty);
		}

		public void Logout()
		{
			var preferences = Application.Context.GetSharedPreferences("UserData", FileCreationMode.Private);
			var editable = preferences.Edit();

			editable.Remove("Token");
			editable.Commit();
		}

		public void OnLoginButtonClicked(LoginModel model, Action calllback)
		{
			if (!string.IsNullOrEmpty(model.Token))
			{
				var preferences = Application.Context.GetSharedPreferences("UserData", FileCreationMode.Private);
				var editable = preferences.Edit();
				editable.PutString("Token", model.Token);
				editable.Commit();

				calllback.Invoke();

				/*var x = Application.Context.GetSharedPreferences("UserData", FileCreationMode.Private);
				var y = x.GetString("Token", string.Empty);

				new AlertDialog.Builder(null)
					.SetPositiveButton("OK", (a, b) =>
					{
					})
					.SetMessage(string.Format("{0} -> {1}", y, result.Token))
					.SetTitle("Login successfull")
					.Show();*/
			}
		}
	}
}