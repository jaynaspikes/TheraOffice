using System.ComponentModel;
using System.Runtime.CompilerServices;
using _4870.library.Models;
using _4870.library.Services;
using App.C.ViewModels;

namespace App.C.Views;


public partial class PhysicianManagementView : ContentPage, INotifyPropertyChanged
{
	public PhysicianManagementView()
	{
		InitializeComponent();
		BindingContext = new PhysicianManagementViewModel(); 
	}

    private void CancelClicked(object sender, EventArgs e)
    {
		  Shell.Current.GoToAsync("//MainPage");
    }

    private void AddClicked(object sender, EventArgs e)
    {

		  Shell.Current.GoToAsync("//PhysicianDetails?physicianId=0");
    }

	private void EditClicked(object sender, EventArgs e)
    {
		  var SelectedPhysicianId = (BindingContext as PhysicianManagementViewModel)?
		    .SelectedPhysician?.Id ?? 0; 
		  Shell.Current.GoToAsync($"//PhysicianDetails?physicianId={SelectedPhysicianId}");
    }

	private void DeleteClicked(object sender, EventArgs e)
    {
		  (BindingContext as PhysicianManagementViewModel)?.Delete();
    }

    private void PhysicianManagement_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
		(BindingContext as PhysicianManagementViewModel)?.Refresh();
    }

    private void RefreshClicked(object sender, EventArgs e)
    {
		(BindingContext as PhysicianManagementViewModel)?.Refresh();
    }

    private void SearchClicked(object sender, EventArgs e)
    {
        (BindingContext as PhysicianManagementViewModel)?.Search();
    }

}