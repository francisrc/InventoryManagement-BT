using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using InventoryManagement_BT.Models;

namespace InventoryManagement_BT.DAL
{
    public class InventoryManagementContext : DbContext
    {
        public InventoryManagementContext() : base("InventoryManagementContext")
        {
        }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<ClientSite> ClientSites { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Model> Models { get; set; }
    }
}