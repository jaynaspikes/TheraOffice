using System.ComponentModel;
using _4870.library.Models;
using _4870.library.Services;
using App.C.ViewModels;

namespace App.C.Views;

[QueryProperty(nameof(PatientId), "patientId")]
public partial class PatientView : ContentPage
{
    public PatientView()
    {
        InitializeComponent();
    }

    public int PatientId {get; set; }
    
    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Patients");
    }

    private void AddClicked(object sender, EventArgs e)
    {
        (BindingContext as PatientViewModel)?.ExecuteAdd();
        // if(patientToAdd?.Model != null)
        // {
        //     PatientServiceProxy
        //     .Current
        //     .AddOrUpdatePatient(patientToAdd.Model);
        // }
        // Shell.Current.GoToAsync("//Patients");
    }

    private void PatientView_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        if(PatientId > 0)
        {
            var model = PatientServiceProxy.Current
                .Patients.FirstOrDefault(p => p.Id == PatientId);
            if (model != null)
            {
                BindingContext = new PatientViewModel(model);
            }
            else
            {
                BindingContext = new PatientViewModel();
            }
        }
        else
        {
            BindingContext = new PatientViewModel();
        }

    }

}