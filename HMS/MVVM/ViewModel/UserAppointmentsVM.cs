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
	public partial class UserAppointmentsVM : ObservableObject
	{
		private ObservableCollection<Appointment> _appointmentsData = new ObservableCollection<Appointment>();

		public ObservableCollection<Appointment> AppointmentsData
		{
			get => _appointmentsData;
			set
			{
				if (_appointmentsData != value)
				{
					_appointmentsData = value;
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

		// Delete prescription command using prism core package
		private DelegateCommand<Appointment> _deleteAppointmentCommand;
		public DelegateCommand<Appointment> DeleteAppointmentCommand =>
			_deleteAppointmentCommand ?? (_deleteAppointmentCommand = new DelegateCommand<Appointment>(ExecuteAppointmentCommand));

		void ExecuteAppointmentCommand(Appointment parameter)
		{
			//string deletedPrescriptionName = "";
			//using (DataContext context = new DataContext())
			//{
			//	Prescription selectedPrescription = parameter;
			//	if (selectedPrescription != null)
			//	{
			//		Prescription pres = context.Prescriptions.Single(x => x.Id == selectedPrescription.Id);
			//		deletedPrescriptionName = pres.Id.ToString();
			//		context.Prescriptions.Remove(pres);
			//		context.SaveChanges();
			//	}
			//}
			//MessageBox.Show($"Prescription #'{deletedPrescriptionName}' deleted sucessfuly 😊 !");
			//MessageBox.Show("Full Name : "+parameter.Patient.FullName + " \nNo of Drugs" + parameter.Dosages.Count + "\nNo of Drugs" + parameter.MedicalTests.Count);


			//using (DataContext context = new DataContext())
			//{
			//	MessageBox.Show("patient id - " + parameter.PatientId.ToString() + "\npatient name - " + context.Patients.Single(x => x.Id == parameter.PatientId).FullName);

			//}

			Read();
		}

		public UserAppointmentsVM()
		{
			Read();
		}


		public void Read()
		{
			using (DataContext context = new DataContext())
			{
				//students = context.Students.ToList();
				_appointmentsData.Clear();
				foreach (var app in context.Appointments)
				{
					_appointmentsData.Add(app);
				}
			}

		}
	}
}
