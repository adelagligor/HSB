using System.ComponentModel.DataAnnotations;

namespace HairStyleBookingApp.Models
{
    public class AppointmentModel
    {
        public Guid IdAppointment { get; set; }
        public Guid IdClient { get; set; }
        public Guid IdService { get; set; }
        public Guid IdEmployee { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime StartsAt { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:MM tt}", ApplyFormatInEditMode = true)]
        public DateTime EndsAt { get; set; }
    }
}
