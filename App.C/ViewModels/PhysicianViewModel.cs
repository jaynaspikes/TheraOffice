using System.Windows.Input;
using _4870.library;
using _4870.library.DTO;
using _4870.library.Models;
using _4870.library.Services;
using CoreML;
using CoreMotion;

namespace App.C.ViewModels
{
    public class PhysicianViewModel
    {
        public PhysicanDTO? Model {get; set;}
        public ICommand? DeleteCommand {get; set; }
        public ICommand? EditCommand{get; set; }


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
            //DeleteCommand = new Command(DoDelete);
            EditCommand = new Command((p) => DoEdit(p as PhysicianViewModel));
        }

        // private void DoDelete()
        // {
        //     if(Id > 0)
        //     {
        //         PhysicianServiceProxy.Current.DeletePhysician(Id);
        //         Shell.Current.GoToAsync("//Patients");
        //     }
        // }

        private void DoEdit(PhysicianViewModel? pvm)
        {
            if(pvm == null)
            {
                return;
            }
            var SelectedPhysicianId = pvm?.Id ?? 0; 
            //Shell.Current.GoToAsync($"//PatientDetails?patientId={SelectedPhysicianId}");
        }

        public PhysicianViewModel()
        {
            Model = new PhysicanDTO(); //3330 automatic not default 
            SetupCommands();
        }

        public PhysicianViewModel(PhysicanDTO? _model)
        {
            Model = _model;
            SetupCommands();
        }

        // public async void ExecuteAdd()
        // {

        //     if(Model != null)
        //     {
        //         await PhysicianServiceProxy
        //         .Current
        //         .AddOrUpdatePatient(Model);
        //     }
        //     await Shell.Current.GoToAsync("//Patients");
        // }

    }
}
