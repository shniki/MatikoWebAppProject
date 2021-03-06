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
        public string UserEmail { get; set; }

        [Required]
        public Status status { get; set; } = Status.Cart;

        [Required]
        public float FullPrice { get; set; } = 0;
        public DateTime DateOrder { get; set; }
        public DateTime EstimatedDateArrival { get; set; }

        public List<ProductsOrders> Products { get; set; } = new List<ProductsOrders>();
    }
}
