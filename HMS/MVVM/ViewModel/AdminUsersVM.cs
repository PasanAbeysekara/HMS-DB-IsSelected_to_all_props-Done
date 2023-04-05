using CommunityToolkit.Mvvm.ComponentModel;
using HMS.MVVM.Model.Authentication;
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
	public partial class AdminUsersVM : ObservableObject
	{
		private ObservableCollection<User> _usersData = new ObservableCollection<User>();

		public ObservableCollection<User> UsersData
		{
			get => _usersData;
			set
			{
				if (_usersData != value)
				{
					_usersData = value;
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
				_usersData.Clear();
				foreach (var usr in context.Users)
				{
					_usersData.Add(usr);
				}
			}

		}

		public AdminUsersVM()
		{
			Read();
		}
	}
}
