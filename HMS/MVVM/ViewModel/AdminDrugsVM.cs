using CommunityToolkit.Mvvm.ComponentModel;
using HMS.MVVM.Model;
using HMS.MVVM.Model.InsidePrescription;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HMS.MVVM.ViewModel
{
	public partial class AdminDrugsVM : ObservableObject
	{
		private ObservableCollection<Drug> _drugsData = new ObservableCollection<Drug>();

		public ObservableCollection<Drug> DrugsData
		{
			get => _drugsData;
			set
			{
				if (_drugsData != value)
				{
					_drugsData = value;
					OnPropertyChanged();
				}
			}
		}


		private DelegateCommand _refreshListCommand;
		public DelegateCommand RefreshListCommand =>
			_refreshListCommand ?? (_refreshListCommand = new DelegateCommand(ExecuteRefreshListCommand));

		void ExecuteRefreshListCommand()
		{
			MessageBox.Show("You clicked refresh");
			Read();
		}


		public void Read()
		{
			using (DataContext context = new DataContext())
			{
				//students = context.Students.ToList();
				_drugsData.Clear();
				foreach (var drg in context.Drugs)
				{
					_drugsData.Add(drg);
				}
			}

		}

		public AdminDrugsVM()
		{
			Read();
		}
	}
}
