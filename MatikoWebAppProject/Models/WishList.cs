using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatikoWebAppProject.Models
{
    public class WishList
    {
        [Key]
        [Required(ErrorMessage = "You must input user's Email Address")]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public int UserEmail { get; set; }

        public int Counter { get; set; }

    }
}
