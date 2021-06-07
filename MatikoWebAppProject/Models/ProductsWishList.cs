using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatikoWebAppProject.Models
{
    public class ProductsWishList
    {

        //product
        public int ProductId { get; set; }
        public Products Product { get; set; }

        //wishlist
        public string UserEmail { get; set; }
        public WishList Wishlist { get; set; }

        //choosings
        public string Size { get; set; }
    }
}

