using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatikoWebAppProject.Models
{
    public enum UserType
    {
        Regular,
        Employee,
        Manager
    }
    public class Users
    {
        [Key]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

       
        public string FirstName { get; set; }


        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        public DateTime Birthday { get; set; }

        [Required]
        public UserType Type { get; set; } = UserType.Regular;

        //address

        public int ZipCode { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
        public string Country { get; set; }

        //orders
        public ICollection<Orders> AllOrdersMade { get; set; }

    }
}