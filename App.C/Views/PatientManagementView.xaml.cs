using System.ComponentModel;
using System.Runtime.CompilerServices;
using _4870.library.Models;
using _4870.library.Services;
using App.C.ViewModels;

namespace App.C.Views;


public partial class PatientManagementView : ContentPage, INotifyPropertyChanged
{
	public PatientManagementView()
	{
		InitializeComponent();
		BindingContext = new PatientManagementViewModel(); 
	}

    private void CancelClicked(object sender, EventArgs e)
    {
		  Shell.Current.GoToAsync("//MainPage");
    }

    private void AddClicked(object sender, EventArgs e)
    {

		  Shell.Current.GoToAsync("//PatientDetails?patientId=0");
    }

	private void EditClicked(object sender, EventArgs e)
    {
		  var SelectedPatientId = (BindingContext as PatientManagementViewModel)?
		    .SelectedPatient?.Id ?? 0; 
		  Shell.Current.GoToAsync($"//PatientDetails?patientId={SelectedPatientId}");
    }

	private void DeleteClicked(object sender, EventArgs e)
    {
		  (BindingContext as PatientManagementViewModel)?.Delete();
    }

    private void PatientManagement_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
		(BindingContext as PatientManagementViewModel)?.Refresh();
    }

    private void RefreshClicked(object sender, EventArgs e)
    {
		(BindingContext as PatientManagementViewModel)?.Refresh();
    }

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as PatientManagementViewModel)?.Search();
    }

}