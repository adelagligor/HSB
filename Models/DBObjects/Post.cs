using System;
using System.Collections.Generic;

namespace HairStyleBookingApp.Models.DBObjects
{
    public partial class Post
    {
        public Guid IdPost { get; set; }
        public Guid IdEmployee { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; } = null!;
        public string Text { get; set; } = null!;

        public virtual Employee IdEmployeeNavigation { get; set; } = null!;
    }
}
