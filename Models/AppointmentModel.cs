namespace HairStyleBookingApp.Models
{
    public class AppointmentModel
    {
        public Guid IdAppointment { get; set; }
        public Guid IdClient { get; set; }
        public Guid IdService { get; set; }
        public Guid IdEmployee { get; set; }
        public DateTime StartsAt { get; set; }
        public DateTime EndsAt { get; set; }
    }
}
