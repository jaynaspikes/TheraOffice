using System.ComponentModel;
using App.C.ViewModels;

namespace App.C.Views;
public partial class AppointmentManagementView : ContentPage
{
	public AppointmentManagementView()
	{
		    InitializeComponent();
        BindingContext = new AppointmentMangementViewModel();
	}

    private void CancelClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//MainPage");
    }

    private void AddClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//AppointmentDetails");
    }




}