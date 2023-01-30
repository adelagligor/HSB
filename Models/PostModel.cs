using System.ComponentModel.DataAnnotations;

namespace HairStyleBookingApp.Models
{
    public class PostModel
    {
        public Guid IdPost { get; set; }
        public Guid IdEmployee { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; } = null!;
        [Required]
        public string Text { get; set; } = null!;
    }
}
