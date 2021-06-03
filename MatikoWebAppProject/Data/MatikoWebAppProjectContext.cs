﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MatikoWebAppProject.Models;

namespace MatikoWebAppProject.Data
{
    public class MatikoWebAppProjectContext : DbContext
    {
        public MatikoWebAppProjectContext (DbContextOptions<MatikoWebAppProjectContext> options)
            : base(options)
        {
        }

        public DbSet<MatikoWebAppProject.Models.Categories> Categories { get; set; }

        public DbSet<MatikoWebAppProject.Models.Products> Products { get; set; }

        public DbSet<MatikoWebAppProject.Models.Orders> Orders { get; set; }

        public DbSet<MatikoWebAppProject.Models.ProductsOrders> ProductsOrders { get; set; }

        public DbSet<MatikoWebAppProject.Models.ProductsWishList> ProductsWishList { get; set; }

        public DbSet<MatikoWebAppProject.Models.Reviews> Reviews { get; set; }

        public DbSet<MatikoWebAppProject.Models.Users> Users { get; set; }

        public DbSet<MatikoWebAppProject.Models.WishList> WishList { get; set; }
    }
}
