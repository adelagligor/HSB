using System;
using System.Collections.Generic;

namespace HairStyleBookingApp.Models.DBObjects
{
    public partial class Appointment
    {
        public Guid IdAppointment { get; set; }
        public Guid IdClient { get; set; }
        public Guid IdService { get; set; }
        public Guid IdStaff { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }
    }
}
