using FoodMgr.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FoodMgr.AppDataContext
{
    public class FoodDataContext : DbContext
    {
        public FoodDataContext(): base("FoodDbContext")
        {

        }

        public DbSet<Catagory> catagories { set; get; }
        public DbSet<Item> items { set; get; }
    }
}