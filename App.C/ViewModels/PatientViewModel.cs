using System.Collections.ObjectModel;
using System.Windows.Input;
using _4870.library;
using _4870.library.DTO;
using _4870.library.Models;
using _4870.library.Services;
using CoreML;
using CoreMotion;

namespace App.C.ViewModels
{
    public class PatientViewModel
    {
        public PatientDTO? Model {get; set;}
        public ICommand? DeleteCommand {get; set; }
        public ICommand? EditCommand{get; set; }

        //private readonly InsuranceService insuranceService;

        //private readonly TreatmentService treatmentService;

        //public ObservableCollection<Insurance> InsuranceOptions => insuranceService.GetAllInsurances(); //Expose insurance options

       //public ObservableCollection<Treatment> TreatmentOptions => treatmentService.GetAllTreatments(); //Expose treatment options


        public int Id
        {
            get
            {
                if(Model == null)
                {
                    return -1;
                }
                return Model.Id;
            }

            set
            {
                if(Model != null && Model.Id != value)
                {
                    Model.Id = value;
                }
            }
        }

        public string Name 
        {
            get => Model?.Name ?? string.Empty; 
            set
            {
                if(Model != null )
                {
                    Model.Name = value;
                }
            }
        }

        public void SetupCommands()
        {
            DeleteCommand = new Command(DoDelete);
            EditCommand = new Command((p) => DoEdit(p as PatientViewModel));
        }

        private void DoDelete()
        {
            if(Id > 0)
            {
                PatientServiceProxy.Current.DeletePatient(Id);
                Shell.Current.GoToAsync("//Patients");
            }
        }

        private void DoEdit(PatientViewModel? pvm)
        {
            if(pvm == null)
            {
                return;
            }
            var SelectedPatientId = pvm?.Id ?? 0; 
            Shell.Current.GoToAsync($"//PatientDetails?patientId={SelectedPatientId}");
        }

        public PatientViewModel()
        {
            Model = new PatientDTO(); //3330 automatic not default 
            SetupCommands();
        }

        public PatientViewModel(PatientDTO? _model)
        {
            Model = _model;
            SetupCommands();
        }

        public async void ExecuteAdd()
            {

                if(Model != null)
                {
                    await PatientServiceProxy
                    .Current
                    .AddOrUpdatePatient(Model);
                }
                await Shell.Current.GoToAsync("//Patients");
            }

    }
}

