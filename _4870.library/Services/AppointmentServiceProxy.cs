﻿using _4870.library.Models;

namespace _4870.library.Services
{
    public class AppointmentServiceProxy
    {
        private static object _lock = new object();
        private int LastKey
        {
            get
            {
                if(Appointments.Any())
                {
                    return Appointments.Select(x => x.Id).Max();
                }
                return 0;
            }
        }
        public List<Appointment> Appointments {get; private set; }
        private static AppointmentServiceProxy _instance;
        public static AppointmentServiceProxy Current
        {
            get
            {
                lock(_lock)
                {
                    if(_instance == null)
                    {
                        _instance = new AppointmentServiceProxy();
                    }
                }
                return _instance;
            }
        }
        private AppointmentServiceProxy()
        {
            Appointments = new List<Appointment>
            {
                new Appointment {Id = 1, StartTime = new DateTime(2024, 10, 9)
                , EndTime = new DateTime(2024, 10, 9), 
                PatientId = 1}
            };
        }
        public void AddorUpdate(Appointment a)
        {
            var isAdd = false;
            if(a.Id <= 0)
            {
                a.Id = LastKey + 1;
                isAdd = true;
            }
            if(isAdd)
            {
                Appointments.Add(a);
            }
        }
    }

    
}

