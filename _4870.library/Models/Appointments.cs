using System.Security.Cryptography.X509Certificates;
using _4870.library.DTO;

namespace _4870.library.Models
{
    public class Appointment
    {
        public Appointment() {}

        public int Id {get; set; }
        public DateTime? StartTime {get; set;}
        public DateTime? EndTime{get; set;}

        public int PatientId {get; set;}

        public PatientDTO? Patient{get; set;}

        public int PhysicianId {get; set;}

        public PhysicanDTO? Physican{get; set;}

    }
}

