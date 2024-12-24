using System.Text.Json.Serialization;
using _4870.library.Models;
using PP.Library.Utilities;
using _4870.library.DTO;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Reflection.Metadata;

namespace _4870.library.Services
{
    public class PhysicianServiceProxy
    {
        private static object _lock = new object();
        public static PhysicianServiceProxy Current
        {
            get
            {
                lock(_lock)
                {
                    if(instance == null)
                    {
                        instance = new PhysicianServiceProxy();
                    }
                    return instance;
                }
            }
        }
        private static PhysicianServiceProxy? instance;

           public int LastKey
        {
            get
            {
                if (Physicians.Any())
                {
                    return Physicians.Select(x => x.Id).Max();
                }
                return 0;
            }
        }
        private List<PhysicanDTO> physicians;
        public List<PhysicanDTO> Physicians
        {
            get
            {
                return physicians;
            }

            private set
            {
                if(physicians != value)
                {
                    physicians = value;
                }
            }
        }

    }
}


// public static List<Physicians> Physicians { get; private set; } = new List<Physicians>();


        // public static void AddPhysician(Physicians physicians)
        // {
        //     Physicians.Add(physicians);
        //     Console.WriteLine("Physican added successfully");
        // }