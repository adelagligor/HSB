using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace HairStyleBookingApp.Models
{
    public class ServiceModel
    {
        public Guid IdService { get; set; }
        public string ServiceName { get; set; } = null!;
        public int TimeInMinutes { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2} €")]
        public decimal Price { get; set; }
    }
}
