using _4870.library.Models;
using _4870.library.Services;
namespace _4870.console{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            bool isContinue = true;
            do{

            Console.WriteLine("Select an option: ");
            Console.WriteLine("A. Add a Patient");
            Console.WriteLine("B. Add a Physician");
            Console.WriteLine("C. Add a Appointment");
            Console.WriteLine("Q. Quit");

            string input = Console.ReadLine() ?? string.Empty;


            if(char.TryParse(input, out char choice))
            {
                switch(choice)
                {
                    case 'a':
                    case 'A':
                        var name = Console.ReadLine();
                        var newPatient = new Patient { Name = name ?? string.Empty };

                        Console.WriteLine("What is the patients address?");
                        string patientadd = Console.ReadLine();
                        newPatient.Address = patientadd;

                        Console.WriteLine("What is the patients birthday?");
                        newPatient.Birthday = Console.ReadLine();
                        PatientServiceProxy.AddPatient(newPatient);
                        
                        Console.WriteLine("What is the patients race?");
                        newPatient.Race = Console.ReadLine();
                        PatientServiceProxy.AddPatient(newPatient);

                        Console.WriteLine("What is the patients gender?");
                        newPatient.Gender = Console.ReadLine();
                        PatientServiceProxy.AddPatient(newPatient);
                        break;

                    case 'b':
                    case 'B':
                        var pname = Console.ReadLine();
                        var newPhysician = new Physicians {Name = pname ?? string.Empty };
                        PhysicianServiceProxy.AddPhysician(newPhysician);

                        Console.WriteLine("What is the physician license number?");
                        newPhysician.LicenseNum = Console.ReadLine();
                        PhysicianServiceProxy.AddPhysician(newPhysician);

                        Console.WriteLine("What is the physician graduation date?");
                        newPhysician.GraduationDate = Console.ReadLine();
                        PhysicianServiceProxy.AddPhysician(newPhysician);

                        Console.WriteLine("What is the physician specialization?");
                        newPhysician.Specializations = Console.ReadLine();
                        PhysicianServiceProxy.AddPhysician(newPhysician);
                        break;
                    
                    case 'c':
                    case 'C':
                        var aname = Console.ReadLine();
                        var newAppoitment = new Appointments {PatientName = aname ?? string.Empty};

                        Console.WriteLine("What is the name of the physican?");
                        newAppoitment.PhysicianName = Console.ReadLine();
                        AppointmentServiceProxy.AddAppointment(newAppoitment);

                        Console.WriteLine("What day is your appoitment?");
                        newAppoitment.DayOfWeek = Console.ReadLine();
                        AppointmentServiceProxy.AddAppointment(newAppoitment);

                        Console.WriteLine("What time is your appoitment?");
                        // newAppoitment.StartTime = Console.ReadLine();
                        // newAppoitment.EndTime = Console.ReadLine();
                        AppointmentServiceProxy.AddAppointment(newAppoitment);
                        break;

                        

                    case 'd':
                    case 'D':
                        PatientServiceProxy.Patients.ForEach(x => Console.WriteLine($"{x.Id}. {x.Name}"));
                        int selectedPatient = int.Parse(Console.ReadLine() ?? "-1");
                        PatientServiceProxy.DeletePatient(selectedPatient);

                        break;
                    case 'q':
                    case 'Q':
                        isContinue = false;
                        break;
                    default:
                        Console.WriteLine("That is an invalid choice!");
                        break;
                }

            }
            else
            {
                Console.WriteLine(choice + " is not a char");
            }
            

            
        }while(isContinue);

        foreach(var patient in PatientServiceProxy.Patients)
        {
            Console.WriteLine($"{patient}");
        }
        }
    } 
}
