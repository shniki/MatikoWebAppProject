using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatikoWebAppProject.Models
{
    public enum Color
    {
        White,
        Grey,
        Black,
        Purple,
        Pink,
        Blue,
        Green,
        Yellow,
        Orange,
        Red,
        Multi
    }
    public enum Gender
    {
        Woman,
        Man,
        Unisex
    }
    public class Products
    {
        //basics
        public int Id { get; set; }

        [Required(ErrorMessage = "You must input product's color")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must input product's price")]
        public float Price { get; set; }

        //design
        [Required(ErrorMessage = "You must input product's color")]
        public Color color { get; set; }

        [Display(Name = "Category")]
        public int CategoriesId { get; set; }

        public Categories Category { get; set; }

        [Required(ErrorMessage = "You must input product's sizes")]

        public Gender Gender { get; set; }

        public string ImageUrl { get; set; }

        List<ProductsOrders> ProOrders { get; set; }

        //List<ProductsWishList> ProWish { get; set; }
        //reviews
        public ICollection<Reviews> AllReviewsMade { get; set; }

        [Required]
        public double Rate { get; set; }

        
    }
}
