using CommunityToolkit.Mvvm.ComponentModel;
using HMS.MVVM.Model;
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
	public partial class AdminDoctorsVM : ObservableObject
	{
		private ObservableCollection<Doctor> _doctorsData = new ObservableCollection<Doctor>();

		public ObservableCollection<Doctor> DoctorsData
		{
			get => _doctorsData;
			set
			{
				if (_doctorsData != value)
				{
					_doctorsData = value;
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
				_doctorsData.Clear();
				foreach (var doc in context.Doctors)
				{
					_doctorsData.Add(doc);
				}
			}

		}

		public AdminDoctorsVM()
		{
			Read();
		}
	}
}
