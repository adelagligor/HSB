using System;
using System.Collections.Generic;

namespace HairStyleBookingApp.Models.DBObjects
{
    public partial class Service
    {
        public Service()
        {
            Appointments = new HashSet<Appointment>();
        }

        public Guid IdService { get; set; }
        public string ServiceName { get; set; } = null!;
        public int TimeInMinutes { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
