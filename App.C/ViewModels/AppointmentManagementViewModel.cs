using System.Collections.ObjectModel;
using _4870.library.Models;
using _4870.library.Services;

namespace App.C.ViewModels
{
    public class AppointmentMangementViewModel
    {
        private AppointmentServiceProxy _appSvc = AppointmentServiceProxy.Current;

        public ObservableCollection<AppointmentViewModel> Appointments
        {
            get
            {
                return new ObservableCollection<AppointmentViewModel>(
                    _appSvc.Appointments.Select(a => new AppointmentViewModel(a)));
            }
        }
    }
}