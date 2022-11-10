namespace HairStyleBookingApp.Models
{
    public class ServiceModel
    {
        public Guid IdService { get; set; }
        public string ServiceName { get; set; } = null!;
        public int TimeInMinutes { get; set; }
        public decimal Price { get; set; }
    }
}
