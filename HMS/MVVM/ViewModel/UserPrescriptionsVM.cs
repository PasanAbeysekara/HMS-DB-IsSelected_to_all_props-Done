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
	public partial class UserPrescriptionsVM : ObservableObject
	{
		private ObservableCollection<Prescription> _prescriptionsData = new ObservableCollection<Prescription>();

		public ObservableCollection<Prescription> PrescriptionsData
		{
			get => _prescriptionsData;
			set
			{
				if (_prescriptionsData != value)
				{
					_prescriptionsData = value;
					OnPropertyChanged();
				}
			}
		}

		[ObservableProperty]
		public string tmperar;

		private DelegateCommand _refreshListCommand;
		public DelegateCommand RefreshListCommand =>
			_refreshListCommand ?? (_refreshListCommand = new DelegateCommand(ExecuteRefreshListCommand));

		void ExecuteRefreshListCommand()
		{
			MessageBox.Show("You clicked refresh");
			Read();
		}

		// Delete prescription command using prism core package
		private DelegateCommand<Prescription> _deletePrescriptionCommand;
		public DelegateCommand<Prescription> DeletePrescriptionCommand =>
			_deletePrescriptionCommand ?? (_deletePrescriptionCommand = new DelegateCommand<Prescription>(ExecuteDeletePrescriptionCommand));

		void ExecuteDeletePrescriptionCommand(Prescription parameter)
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
			using (DataContext context = new DataContext())
			{
				MessageBox.Show("patient id - " + parameter.PatientId.ToString() + "\npatient name - " + context.Patients.Single(x => x.Id == parameter.PatientId).FullName);

			}

			Read();
		}

		public UserPrescriptionsVM()
		{
			Read();
		}


		public void Read()
		{
			using (DataContext context = new DataContext())
			{
				//students = context.Students.ToList();
				_prescriptionsData.Clear();
				foreach (var pres in context.Prescriptions)
				{
					_prescriptionsData.Add(pres);
				}
			}

		}
	}
}
