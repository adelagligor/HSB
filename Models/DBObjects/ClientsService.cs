using System;
using System.Collections.Generic;

namespace HairStyleBookingApp.Models.DBObjects
{
    public partial class ClientsService
    {
        public Guid IdService { get; set; }
        public Guid IdClient { get; set; }

        public virtual Client IdClientNavigation { get; set; } = null!;
        public virtual Service IdServiceNavigation { get; set; } = null!;
    }
}
