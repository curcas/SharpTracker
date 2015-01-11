using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using SharpTracker.Core;

namespace SharpTracker
{
	public class WorkTypeListeViewModel : BaseViewModel
	{ 
		private ObservableCollection<WorkTypeModel> _teams = new ObservableCollection<WorkTypeModel>();
		private List<WorkTypeModel> keepTeams = new List<WorkTypeModel>();
		/// <summary>
		/// gets or sets the news items
		/// </summary>
		public ObservableCollection<WorkTypeModel> Teams
		{
			get { return _teams; }
			set { _teams = value; OnPropertyChanged("Teams"); }
		}

		public WorkTypeListeViewModel ()
		{
		}

		public void Filter(string text){
			Teams.Clear();
			var list = keepTeams.Where (t => t.Name.ToLower ().Contains (text.ToLower ())).ToList ();
			foreach (var item in list) {
				Teams.Add (item);
			}
		}

		public async void Load(IApp app){
			var list = await Request<List<WorkTypeModel>>.Get("/WorkingType", null, app);

			foreach (var item in list.OrderBy(t => t.Name))
			{
				Teams.Add(item);
			}
			keepTeams = Teams.ToList();
		}
	}
}

