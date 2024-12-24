using System.Collections.ObjectModel;
using _4870.library.Models;

namespace _4870.library.Services
{
    public class InsuranceService
    {
        // Collection of insurances
        public ObservableCollection<Insurance> Insurances { get; private set; }

        public InsuranceService()
        {
            Insurances = new ObservableCollection<Insurance>();
            // Example: Load existing insurances (if any)
            LoadInitialInsurances();
        }

        // Method to retrieve all insurances
        public ObservableCollection<Insurance> GetAllInsurances()
        {
            return Insurances; // Return the collection of insurances
        }

        // Method to add a new insurance
        public void AddInsurance(Insurance insurance)
        {
            Insurances.Add(insurance);
        }

        // Method to remove an insurance
        public void RemoveInsurance(Insurance insurance)
        {
            Insurances.Remove(insurance);
        }

        // Method to load initial insurance records (if necessary)
        private void LoadInitialInsurances()
        {
            // Add some default insurances for demonstration
            Insurances.Add(new Insurance { InsuranceProvider = "Provider A", PlanName = "Premium", CoveragePercentage = 80 });
            Insurances.Add(new Insurance { InsuranceProvider = "Provider B", PlanName = "Basic", CoveragePercentage = 70 });
        }
    }
}

