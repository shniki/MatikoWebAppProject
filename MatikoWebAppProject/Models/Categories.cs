using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatikoWebAppProject.Models
{
    public class Categories
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Products> Products { get; set; }
        public String Sizes { get; set; } = "S M L";
        public string ImageUrl { get; set; }
    }
}
