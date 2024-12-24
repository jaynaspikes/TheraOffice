using _4870.library.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ToDoApplication.Persistence
{
    public class Filebase
    {
        private string _root;
        private string _patientRoot;
        private Filebase _instance;
        public Filebase Current
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new Filebase();
                }
                return _instance;
            }
        }
        private Filebase()
        {
            _root = @"C:\user\jaynaspikes"; //filepads on mac foward slashes only 
           _patientRoot = $"{_root}\\Patients";
        }

        public int LastKey //function enum because it takes in a single patient 
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

        public Patient AddOrUpdate(Patient patient)
        {

            //set up a new Id if one doesn't already exist
            if(patient.Id <= 0)
            {
                patient.Id = LastKey + 1;
            }

            //go to the right place which table to go to
            string path = $"{_patientRoot}\\{patient.Id}.json";

            //if the item has been previously persisted
            if(File.Exists(path))
            {
                //blow it up
                File.Delete(path);
            }

            //write the file
            File.WriteAllText(path, JsonConvert.SerializeObject(patient));
            
            //return the item, which now has an id
            return patient;
        }
        public List<Patient> Patients //replace with physicans or appoitments  Read of CRUD
        {
            get
            {
                var root = new DirectoryInfo(_patientRoot);
                var _patients = new List<Patient>();
                foreach(var patientFile in root.GetFiles())
                {
                    var patient = JsonConvert
                    .DeserializeObject<Patient>
                    (File.ReadAllText(patientFile.FullName));
                    if(patient != null)
                    {
                        _patients.Add(patient);
                    }
                }
                return _patients;
            }
        }

        public bool Delete(string type, string id) //copy and paste 
        {
            return true;
        }
    }     
}