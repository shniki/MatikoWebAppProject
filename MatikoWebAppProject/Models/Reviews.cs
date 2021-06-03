using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatikoWebAppProject.Models
{
    public class Reviews
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You must input product id")]
        [Display(Name = "Product")]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "You must input user's email")]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "You must input title ")]
        public string Title { get; set; }

        public string Describtion { get; set; }

        public int Rate { get; set; } = 0;
    }
}