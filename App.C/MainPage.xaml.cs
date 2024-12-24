using App.C.Views;

namespace App.C;

public partial class MainPage : ContentPage
{
	// public MainPage()
	// {
	// 	InitializeComponent();
	// }

    private void PatientsClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//Patients");
    }

  // private async void PatientsClicked(object sender, EventArgs e)
  // {
  //     try
  //     {
  //         // This will now navigate correctly
  //         await Shell.Current.GoToAsync("//Patients");
  //     }
  //     catch (Exception ex)
  //     {
  //         // Handle any navigation errors
  //         Console.WriteLine($"Navigation error: {ex.Message}");
  //     }
  // }

    private void AppointmentsClicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync("//Appointments");
    }

    private void PhysiciansClicked(object sender, EventArgs e)
    {
      Shell.Current.GoToAsync("//Physicians");
    }

}

