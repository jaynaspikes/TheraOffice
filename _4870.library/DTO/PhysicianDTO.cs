using _4870.library.Models;
using _4870.library.Services;

namespace _4870.library.DTO
{
    public class PhysicanDTO
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

        public string Name { get; set; }

        public string LicenseNum { get; set; }

        public string GraduationDate { get; set; }

        public string Specializations { get; set; }

        public PhysicanDTO() { }

        public PhysicanDTO(Physician p)
        {
            Id = p.Id;
            Name = p.Name;
            LicenseNum = p.LicenseNum;
            GraduationDate = p.GraduationDate;
            Specializations = p.Specializations;
        }
    }
}