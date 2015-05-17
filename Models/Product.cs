using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Tema2_2.Models
{
    public class Product
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }

    /*
    public class ProductDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
    */
}