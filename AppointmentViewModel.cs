using System.Collections.ObjectModel;
using System.Windows.Input;
using _4870.library.Models;
using _4870.library.Services;
using CoreML;
using CoreMotion;

namespace App.C.ViewModels
{

public class AppointmentViewModel
{
    public Appointment? Model { get; set; }

    public string PatientName
        {
            get
            {
                if(Model != null && Model.PatientId > 0)
                {
                    if(Model.Patient == null)
                    {
                        Model.Patient = PatientServiceProxy
                            .Current
                            .Patients
                            .FirstOrDefault(p => p.Id == Model.PatientId);
                    }

                }
                return Model?.Patient?.Name ?? string.Empty;
            }
        }


        public Patient? SelectedPatient
        {
            get
            {
                return Model?.Patient;
            }
            set
            {
                var selectedPatient = value;
                if(Model != null)
                {
                    Model.Patient = selectedPatient;
                    Model.PatientId = selectedPatient?.Id ?? 0;
                }
            }
        }

        public ObservableCollection<Patient> Patients {
            get
            {
                return new ObservableCollection<Patient>(PatientServiceProxy.Current.Patients);
            }
        }

        public DateTime MinStartDate 
        {
            get
            {
                return DateTime.Today;
            }
        }

        public void RefreshTime()
        {
             if(Model != null)
             {
                 if(Model.StartTime != null)
                 {
                   Model.StartTime = StartDate;
                   Model.StartTime = Model.StartTime.Value.AddHours(StartTime.Hours);
                 }         
             }
        }

        public DateTime StartDate 
        {
            get
            {
                return Model?.StartTime?.Date ?? DateTime.Today;
            }
            set
            {
                if(Model != null)
                {
                    Model.StartTime = value;
                    RefreshTime();
                }
            }
        }
        
        public TimeSpan StartTime { get; set; }


        public AppointmentViewModel() 
        {
            Model = new Appointment();
        }
        public AppointmentViewModel(Appointment a)
        {
            Model = a;
        }

        public void AddOrUpdate ()
        {
            if(Model != null)
            {
                AppointmentServiceProxy.Current.AddorUpdate(Model);
            }
        }
    }
}
