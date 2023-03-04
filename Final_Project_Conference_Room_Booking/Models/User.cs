using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Final_Project_Conference_Room_Booking.Models
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string Name { get; set; } 
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [Display(Name = "Please Enter Email")]
        public string Email { get; set; } 

        [Required(ErrorMessage = "Please Enter Password")]
        [Display(Name = "Please Enter Password")]
        public string Password { get; set; } 
        public bool IsDeleted { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
