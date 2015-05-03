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
        public DbSet<Asset> Assets { get; set; }
        public DbSet<ClientSite> ClientSites { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Model> Models { get; set; }

        public InventoryManagementContext() : base("InventoryManagementContext")
        {
            Database.SetInitializer<InventoryManagementContext>(new DefaultDBInitializer());
        }


    }

    public class DefaultDBInitializer : DropCreateDatabaseAlways<InventoryManagementContext>
    {
        protected override void Seed(InventoryManagementContext context)
        {
            //create locations
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

            //create clientsites
            IList<ClientSite> defaultClientSites = new List<ClientSite>();

            defaultClientSites.Add(new ClientSite() { Name = "Lampo" });
            defaultClientSites.Add(new ClientSite() { Name = "Rollins" });
            defaultClientSites.Add(new ClientSite() { Name = "BCBSTN" });
            defaultClientSites.Add(new ClientSite() { Name = "Healthways" });
            defaultClientSites.Add(new ClientSite() { Name = "MapCo" });
            defaultClientSites.Add(new ClientSite() { Name = "Regions" });

            foreach (var clientSite in defaultClientSites)
            {
                context.ClientSites.Add(clientSite);
            }

            context.SaveChanges();

            base.Seed(context);
        }
    }
}