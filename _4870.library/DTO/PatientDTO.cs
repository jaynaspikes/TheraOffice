using _4870.library.Models;
using _4870.library.Services;

namespace _4870.library.DTO
{
    public class PatientDTO
    {
        public override string ToString()
        {
            return $"[{Id}] {Name}";
        }

        //Remove this put it on view model instead 
        public string Display
        {
            get
            {
                return $"[{Id}] {Name}";
            }
        }
        public int Id { get; set; }
    

        public string? Name {get; set;}
        public DateTime Birthday { get; set; }
        public string? Address { get; set; }
        public string? SSN { get; set; }
        public string? Race { get; set; }
        public string? Gender{ get; set; }
        public PatientDTO() { }

        public PatientDTO(Patient p) //conversion constructor
        {
            Id = p.Id;
            Name = p.Name;
            Birthday = p.Birthday;
            Address = p.Address;
            SSN = p.SSN;
        }
    }
}



