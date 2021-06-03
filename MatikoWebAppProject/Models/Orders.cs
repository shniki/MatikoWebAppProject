using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MatikoWebAppProject.Models
{
    public enum Status
    {
        Cart,
        Paid,
        Shipped,
        Arrived
    }
    public class Orders
    {
        public int Id { get; set; }

        [Required]
        public int UserEmail { get; set; }

        [Required]
        public Status status { get; set; } = Status.Cart;

        [Required]
        public float FullPrice { get; set; } = 0;
        public DataType DateOrder { get; set; }
        public DataType EstimatedDateArrival { get; set; }

        //public ICollection<ProductsOrders> Products { get; set; }
    }
}
