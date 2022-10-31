using System;
using System.Collections.Generic;

namespace HairStyleBookingApp.Models.DBObjects
{
    public partial class Client
    {
        public Guid IdClient { get; set; }
        public string Name { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string? Email { get; set; }
        public string? Notes { get; set; }
    }
}
