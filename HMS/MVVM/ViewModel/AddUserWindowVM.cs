using CommunityToolkit.Mvvm.ComponentModel;
using HMS.MVVM.Model;
using HMS.MVVM.Model.Authentication;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HMS.MVVM.ViewModel
{


	public partial class AddUserWindowVM : ObservableObject, ICloseWindows
	{

		// #begin for ICloseWindows
		public Action CloseAction { get; internal set; }
		public Action Close { get; set; }
		// #end

		[ObservableProperty]
		public string userName;

		[ObservableProperty]
		public string userPassword;


		private bool[] _modeArray = new bool[] { true, false, false };
		public bool[] ModeArray
		{
			get { return _modeArray; }
		}
		public int SelectedMode
		{
			get { return Array.IndexOf(_modeArray, true); }
		}

		private DelegateCommand _closeCommand;
		public DelegateCommand CloseCommand =>
			_closeCommand ?? (_closeCommand = new DelegateCommand(ExecuteCloseCommand));

		void ExecuteCloseCommand()
		{
			Close?.Invoke();
		}

		private DelegateCommand _createCommand;
		public DelegateCommand CreateCommand =>
			_createCommand ?? (_createCommand = new DelegateCommand(ExecuteCreateommand));

		void ExecuteCreateommand()
		{
			using (DataContext context = new DataContext())
			{
				context.Users.Add(new User ( UserName,UserPassword, ModeArray[0] ));
				context.SaveChanges();
			}
			MessageBox.Show("Please click 'Refresh' to see the updated User list 😊");
			Close?.Invoke();
		}

		public AddUserWindowVM()
		{
		}

	}
}
