using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using _4870.library.Models;
using _4870.library.Services;

namespace App.C.ViewModels
{
    internal class PhysicianManagementViewModel: INotifyPropertyChanged
    {
        public PhysicianManagementViewModel()
        {
            SortChoices = new List<SortChoiceEnum> 
            { 
                SortChoiceEnum.None
                , SortChoiceEnum.NameAscending
                , SortChoiceEnum.NameDescending
            };

            SortChoice = SortChoiceEnum.NameAscending;
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<SortChoiceEnum> SortChoices { get; set; }

        private SortChoiceEnum sortChoice;        
        public SortChoiceEnum SortChoice
        { 
            get
            {
                return sortChoice;
            }
            set
            {
                if(sortChoice != value )
                {
                    sortChoice = value;
                    NotifyPropertyChanged("Physician");
                }
            }
        
        }

        public Physician? SelectedPhysician { get; set; }
        public string? Query { get; set; }
        public ObservableCollection<PhysicianViewModel> Physicians
        {
            get
            {
                var retVal = new ObservableCollection<PhysicianViewModel>(
                    PhysicianServiceProxy
                    .Current
                    .Physicians
                    .Where(p =>p != null)
                    .Where(p => p.Name.ToUpper().Contains(Query?.ToUpper() ?? string.Empty))
                    .Take(100)                                  
                    .Select(p => new PhysicianViewModel(p))
                    );

                if(SortChoice == SortChoiceEnum.NameAscending)
                {
                    return 
                        new ObservableCollection<PhysicianViewModel>(retVal.OrderBy(p => p.Name));
                }
                else
                {
                     return 
                        new ObservableCollection<PhysicianViewModel>(retVal.OrderByDescending(p => p.Name));
                }
            }
        }

        public void Delete()
        {
            if(SelectedPhysician == null)
            {
                return;
            }
            PatientServiceProxy.Current.DeletePatient(SelectedPhysician.Id);

            Refresh();
        }

        public void Refresh()
        {
            NotifyPropertyChanged(nameof(Physicians)); 
        }
        
        public async void Search()
        {
            if(Query != null)
            {
                await PatientServiceProxy.Current.Search(Query);
            }
            Refresh();
        }
    }
}
