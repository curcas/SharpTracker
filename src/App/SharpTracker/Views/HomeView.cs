﻿using SharpTracker.Core;
using SharpTracker.Core.Views;
using Xamarin.Forms;

namespace SharpTracker.Views
{
	public class HomeView : BaseContentPage
	{
		public HomeView(IApp app)
			: base(app)
		{
			Content = new StackLayout
			{
				Children =
				{
					new Label
					{
						Text = "Hello, Forms !",
					}
				}
			};
		}
	}
}