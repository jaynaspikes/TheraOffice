using System.Text.Json.Serialization;
using _4870.library.Models;
using PP.Library.Utilities;
using _4870.library.DTO;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Reflection.Metadata;


namespace _4870.library.Services
{
    public class PatientServiceProxy
    {
        private static object _lock = new object();
        public static PatientServiceProxy Current
        {
            get
            {
                lock(_lock)
                {
                    if(instance == null)
                    {
                        instance = new PatientServiceProxy();
                    }
                    return instance;
                }
            }
        }
        private static PatientServiceProxy? instance;
        private PatientServiceProxy()
        {
            instance = null;

            var patientsData = new WebRequestHandler().Get("/Patient").Result; //problem set it to null

            Patients = JsonConvert.DeserializeObject<List<PatientDTO>>(patientsData) ?? new List<PatientDTO>(); //problem 
            //wait until someone asks for it 
        }
        
        public int LastKey
        {
            get
            {
                if (Patients.Any())
                {
                    return Patients.Select(x => x.Id).Max();
                }
                return 0;
            }
        }
        private List<PatientDTO> patients;
        public List<PatientDTO> Patients
        {
            get
            {
                return patients;
            }

            private set
            {
                if(patients != value)
                {
                    patients = value;
                }
            }
        }

        public async Task<List<PatientDTO>> Search(string query)
        {
            var patientsPayload = await new WebRequestHandler()
                .Post("/Patients/Search", new Query(query));

            Patients = JsonConvert.DeserializeObject<List<PatientDTO>>(patientsPayload)
                ?? new List<PatientDTO>();
            
            return Patients;
        }

        public async Task<PatientDTO?> AddOrUpdatePatient(PatientDTO patient)
        {
            var payload = await new WebRequestHandler().Post("/patient", patient);
            var newPatient = JsonConvert.DeserializeObject<PatientDTO>(payload);
            if(newPatient != null &&  newPatient.Id > 0 && patient.Id == 0)
            {
                //new patient to be added to the list
                Patients.Add(newPatient);
            }
            else if(newPatient != null && patient != null && patient.Id > 0 && patient.Id == newPatient.Id)
            {
                //edit, exchange the object in the list //breakpoint
                var currentPatient = Patients.FirstOrDefault(p => p.Id == newPatient.Id);
                var index = Patients.Count;
                if(currentPatient != null)
                {
                    index = Patients.IndexOf(currentPatient);
                    Patients.RemoveAt(index);
                }
                Patients.Insert(index, newPatient);
            }
            return newPatient;
        }

        public async void DeletePatient(int id)
        {
            var PatientToRemove = Patients.FirstOrDefault(p => p.Id == id);
            if (PatientToRemove != null)
            {
                //Patients.Remove(PatientToRemove);
                await new WebRequestHandler().Delete($"/Patient/{id}");
                
            }
        }
    }
}

