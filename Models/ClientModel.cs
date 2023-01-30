using System.ComponentModel;

namespace HairStyleBookingApp.Models
{
    public class ClientModel
    {
        public Guid IdClient { get; set; }
        [DisplayName("Client Name")]
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Notes { get; set; } = null!;
    }
}
