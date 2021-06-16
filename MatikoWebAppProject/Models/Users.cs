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
        [Required(ErrorMessage = "You must input your Email Address")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "You must input your first name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "You must input your last name")]

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

        [Required(ErrorMessage = "You must input user's zip code")]
        public int ZipCode { get; set; }

        [Required(ErrorMessage = "You must input user's address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "You must input user's city")]
        public string City { get; set; }

        [Required(ErrorMessage = "You must input user's country")]
        public string Country { get; set; }

        //orders
        public ICollection<Orders> AllOrdersMade { get; set; }

    }
}