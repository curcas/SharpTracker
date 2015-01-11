using System;
using SharpTracker.Core.Views;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;

namespace SharpTracker
{
	public class WorkTypeList : BaseContentPage
	{
		private ListView ListView = new ListView();
		private SearchBar searchBar = new SearchBar();

		private WorkTypeListeViewModel _workTypeListeViewModel;
		private WorkTypeListeViewModel Model
		{
			get { return _workTypeListeViewModel ?? (_workTypeListeViewModel = new WorkTypeListeViewModel()); }
		}

		public WorkTypeList ()
		{
			searchBar.TextChanged += onSearchChange;
			ListView.ItemsSource = Model.Teams;

			var cell = new DataTemplate(typeof(TextCell));

			cell.SetBinding (ImageCell.TextProperty, "Id");
			cell.SetBinding(ImageCell.DetailProperty, "Name");

			ListView.ItemTemplate = cell;

			Content = new StackLayout {
				Children = {
					searchBar,
					ListView
				}
			};
		}

		void onSearchChange (object sender, TextChangedEventArgs e)
		{
			Model.Filter(searchBar.Text);
		}

		public override void onLoad ()
		{
			Model.Load (base.App);
		}
	}
}
