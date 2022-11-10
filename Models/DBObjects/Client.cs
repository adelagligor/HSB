using System;
using System.Collections.Generic;

namespace HairStyleBookingApp.Models.DBObjects
{
    public partial class Client
    {
        public Client()
        {
            Appointments = new HashSet<Appointment>();
        }

        public Guid IdClient { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Notes { get; set; } = null!;

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
