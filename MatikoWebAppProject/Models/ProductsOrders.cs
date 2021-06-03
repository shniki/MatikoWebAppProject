using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MatikoWebAppProject.Models
{
    public class ProductsOrders
    {
        public int ProductsOrdersId { get; set; }
        //product
        //public int ProductId { get; set; }
        public Products Product { get; set; }

        //order
        //public int OrderId { get; set; }
        public Orders Order { get; set; }

        //choosings
        public string Size { get; set; }
        public int Amount { get; set; }
    }
}
