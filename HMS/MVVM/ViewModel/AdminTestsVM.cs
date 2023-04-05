using CommunityToolkit.Mvvm.ComponentModel;
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
	public partial class AdminTestsVM : ObservableObject
	{
		private ObservableCollection<Test> _testsData = new ObservableCollection<Test>();

		public ObservableCollection<Test> TestsData
		{
			get => _testsData;
			set
			{
				if (_testsData != value)
				{
					_testsData = value;
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
				_testsData.Clear();
				foreach (var tst in context.Tests)
				{
					_testsData.Add(tst);
				}
			}

		}

		public AdminTestsVM()
		{
			Read();
		}
	}
}
