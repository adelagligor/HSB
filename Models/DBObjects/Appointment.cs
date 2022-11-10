using System;
using System.Collections.Generic;

namespace HairStyleBookingApp.Models.DBObjects
{
    public partial class Appointment
    {
        public Guid IdAppointment { get; set; }
        public Guid IdClient { get; set; }
        public Guid IdService { get; set; }
        public Guid IdEmployee { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }

        public virtual Client IdClientNavigation { get; set; } = null!;
        public virtual Employee IdEmployeeNavigation { get; set; } = null!;
        public virtual Service IdServiceNavigation { get; set; } = null!;
    }
}
