namespace HairStyleBookingApp.Models
{
    public class PostModel
    {
        public Guid IdPost { get; set; }
        public Guid IdEmployee { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; } = null!;
        public string Text { get; set; } = null!;
    }
}
