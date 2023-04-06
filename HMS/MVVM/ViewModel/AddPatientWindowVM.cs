using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HMS.MVVM.ViewModel
{
	interface ICloseWindows
	{
		Action Close { get; set; }
	}
	public class AddPatientWindowVM : INotifyPropertyChanged, ICloseWindows
	{
		// #begin INotifyPropertyChanged Interface 
		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		// #end

		// #begin for ICloseWindows
		public Action CloseAction { get; internal set; }
		public Action Close { get; set; }
		// #end

		private string _fullName;

		public string FullName { get { return _fullName; } set { _fullName = value; OnPropertyChanged(nameof(FullName)); } }

		private string _email;

		public string Email { get { return _email; } set { _email = value; OnPropertyChanged(nameof(Email)); } }

		private DateTime _dateOfBirth;

		public DateTime DateOfBirth { get { return _dateOfBirth; } set { _dateOfBirth = value; OnPropertyChanged(nameof(DateOfBirth)); } }

		public List<string> _genders;
		public List<string> Genders { get { return _genders; } set { _genders = value; OnPropertyChanged(nameof(Genders)); } }

		private string _gender;

		public string Gender { get { return _gender; } set { _gender = value; OnPropertyChanged(nameof(Gender)); } }


		private string _phone;

		public string Phone { get { return _phone; } set { _phone = value; OnPropertyChanged(nameof(Phone)); } }

		private string _blood;

		public string Blood { get { return _blood; } set { _blood = value; OnPropertyChanged(nameof(Blood)); } }

		private string _address;

		public string Address { get { return _address; } set { _address = value; OnPropertyChanged(nameof(Address)); } }

		private string _weight;

		public string Weight { get { return _weight; } set { _weight = value; OnPropertyChanged(nameof(Weight)); } }

		private string _height;

		public string Height { get { return _height; } set { _height = value; OnPropertyChanged(nameof(Height)); } }


		// Close Button Command
		private DelegateCommand _closeCommand;
		public DelegateCommand CloseCommand =>
			_closeCommand ?? (_closeCommand = new DelegateCommand(ExecuteCloseCommand));

		void ExecuteCloseCommand()
		{
			Close?.Invoke();
		}

		// Create Button Command
		private DelegateCommand _createCommand;
		public DelegateCommand CreateCommand =>
			_createCommand ?? (_createCommand = new DelegateCommand(ExecuteCreateCommand));


		void ExecuteCreateCommand()
		{
			using (DataContext context = new DataContext())
			{
				context.Patients.Add(new Model.Patient { FullName = _fullName, Email = _email, BirthDay = _dateOfBirth.ToShortDateString(), Gender = _gender[0], Phone = _phone, BloodGroup = _blood, Address = _address, Weight = Double.Parse(_weight), Height = Double.Parse(_height) });
				context.SaveChanges();
			}
			MessageBox.Show("Refresh the student records to see the changes 😊");
			Close?.Invoke();
		}

		public AddPatientWindowVM()
		{
			Genders = new List<string> { "Male", "Female" };
			string dateString = "2000-01-01";
			DateTime date = DateTime.ParseExact(dateString, "yyyy-MM-dd", CultureInfo.InvariantCulture);
			_dateOfBirth = date;
		}

	}
}
