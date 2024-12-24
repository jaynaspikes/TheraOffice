using _4870.library.Models;
using Api.Clinic.Enterprise;
using Microsoft.AspNetCore.Mvc;
using _4870.library.DTO;

namespace Api.Clinic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;

        public PatientController(ILogger<PatientController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<PatientDTO> Get()
        {
           return new PatientEC().Patients;
        //    return new List<Patient> {
        //         new Patient{Name = "Test", Id = 0}
        //    };
        }

        //maybe comment out this part 
        [HttpGet("{id}")]
        public PatientDTO? GetById(int id)
        {
           return new PatientEC().GetById(id);
        }

        [HttpDelete("{id}")]
        public PatientDTO? Delete(int id)
        {
            return new PatientEC().Delete(id);
        }

        [HttpPost("Search")]
        public List<PatientDTO> Search([FromBody] Query q)
        {
            return new PatientEC().Search(q?.Content ?? string.Empty)?.ToList() ?? new List<PatientDTO>();
        }

        [HttpPost]
        public Patient? AddOrUpdate([FromBody]PatientDTO? patient)
        {
            return new PatientEC().AddOrUpdate(patient); //breakpoint
        }
    }
}