using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Final_Project_Conference_Room_Booking.Models
{
    public partial class ApplicationUser: IdentityUser<int>
    {
        public ApplicationUser()
        {
            Bookings = new HashSet<Booking>();
        }

        public bool IsDeleted { get; set; } = false;

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
