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
            Database.SetInitializer<InventoryManagementContext>(new LocationsDBInitializer());
        }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<ClientSite> ClientSites { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Model> Models { get; set; }
    }

    public class LocationsDBInitializer : DropCreateDatabaseAlways<InventoryManagementContext>
    {
        protected override void Seed(InventoryManagementContext context)
        {
            IList<Location> defaultLocations = new List<Location>();

            defaultLocations.Add(new Location() { Name = "BHM" });
            defaultLocations.Add(new Location() { Name = "ATL" });
            defaultLocations.Add(new Location() { Name = "CHT" });
            defaultLocations.Add(new Location() { Name = "NSH" });
            defaultLocations.Add(new Location() { Name = "MBL" });
            defaultLocations.Add(new Location() { Name = "CLT" });

            foreach (var location in defaultLocations)
            {
                context.Locations.Add(location);
            }

            base.Seed(context);
        }
    }
}