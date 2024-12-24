using _4870.library.DTO;

namespace _4870.library.Models
{
    public class Physician
    {
        public override string ToString()
        {
            return $"[{Id}] {Name}";
        }

        public string Display
        {
            get
            {
                return $"[{Id}] {Name}";
            }
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public string LicenseNum { get; set; }

        public string GraduationDate { get; set; }

        public string Specializations { get; set; }

        public Physician()
        {
            Name = string.Empty;
            LicenseNum = string.Empty;
            GraduationDate = string.Empty;
            Specializations = string.Empty;
        }

        public Physician (PhysicanDTO p)
        {
            Id = p.Id;
            LicenseNum = p.LicenseNum;
            GraduationDate = p.GraduationDate;
            Specializations = p.Specializations;

        }
    }
    
}


