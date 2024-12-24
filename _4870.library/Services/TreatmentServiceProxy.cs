// using System.Collections.ObjectModel;
// using _4870.library.Models;

// namespace _4870.library.Services
// {
//     public class TreatmentService
//     {
//          // Collection of treatments
//         public ObservableCollection<Treatment> Treatments { get; private set; }

//         public TreatmentService()
//         {
//             Treatments = new ObservableCollection<Treatment>();
//             // Example: Load existing treatments (if any)
//             LoadInitialTreatments();
//         }

//         // Method to retrieve all treatments
//         public ObservableCollection<Treatment> GetAllTreatments()
//         {
//             return Treatments; // Return the collection of treatments
//         }

//         // Method to add a new treatment
//         public void AddTreatment(Treatment treatment)
//         {
//             Treatments.Add(treatment);
//         }

//         // Method to remove a treatment
//         public void RemoveTreatment(Treatment treatment)
//         {
//             Treatments.Remove(treatment);
//         }

//         // Method to load initial treatment records (if necessary)
//         private void LoadInitialTreatments()
//         {
//             // Add some default treatments for demonstration
//             Treatments.Add(new Treatment { Name = "Consultation", Price = 100 });
//             Treatments.Add(new Treatment { Name = "X-Ray", Price = 200 });
//         }
//     }
// }

// using System.Collections.ObjectModel;
// using _4870.library.Models;  // Ensure this is the correct namespace for Treatment class

// namespace _4870.library.Services
// {
//     public class TreatmentService
//     {
//         // Collection of treatments
//         public ObservableCollection<Treatment> Treatments { get; private set; }

//         public TreatmentService()
//         {
//             Treatments = new ObservableCollection<Treatment>();
//             // Load initial treatments (if needed)
//             LoadInitialTreatments();
//         }

//         // Method to retrieve all treatments
//         public ObservableCollection<Treatment> GetAllTreatments()
//         {
//             return Treatments;  // Return the collection of treatments
//         }

//         // Method to add a new treatment
//         public void AddTreatment(Treatment treatment)
//         {
//             Treatments.Add(treatment);  // Add a treatment to the collection
//         }

//         // Method to remove a treatment
//         public void RemoveTreatment(Treatment treatment)
//         {
//             Treatments.Remove(treatment);  // Remove the specified treatment
//         }

//         // Method to load initial treatment records (if necessary)
//         private void LoadInitialTreatments()
//         {
//             // Add some default treatments for demonstration
//             Treatments.Add(new Treatment { Name = "Consultation", Price = 100 });
//             Treatments.Add(new Treatment { Name = "X-Ray", Price = 200 });
//         }
//     }
// }
