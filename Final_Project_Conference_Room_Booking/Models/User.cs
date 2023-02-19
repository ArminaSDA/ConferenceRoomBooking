using System;
using System.Collections.Generic;

namespace Final_Project_Conference_Room_Booking.Models
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsDeleted { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
