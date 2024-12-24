
using _4870.library.DTO;

namespace _4870.library.Models
{
    public class Patient
    {
        public override string ToString()
        {
            return $"[{Id}] {Name}";
        }

        //TODO: Remove this and put it on a ViewModel instead
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
        public string Address { get; set; }
        public string SSN { get; set; }
        public string Race { get; set; }
        public string Gender{ get; set; }

        public string abcd1 { get; set; }
        public string abcd2 { get; set; }
        public string abcd3 { get; set; }
        public string abcd4 { get; set; }
        public string abcd5 { get; set; }
        public string abcd6 { get; set; }
        public string abcd7 { get; set; }
        public string abcd8 { get; set; }

        public Patient()
        {   
            Name = string.Empty;
            Address = string.Empty;
            Birthday = DateTime.MinValue;
            SSN = string.Empty;
            Race = string.Empty;
            Gender = string.Empty;
        }

        public Patient(PatientDTO p)
        {
            Id = p.Id;
            Name = p.Name;
            Birthday = p.Birthday;
            SSN = p.SSN;
            Race = p.Race;
            Gender = p.Gender;
        }
    }

}


