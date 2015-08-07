using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using InventoryManagement_BT.Models;
using InventoryManagement_BT.ViewModels;

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

        public InventoryManagementContext()
            : base("InventoryManagementContext")
        {
            Database.SetInitializer(new DefaultDBInitializer());
        }

        public DbSet<AssetFormViewModel> AssetFormViewModels { get; set; }
    }

    public class DefaultDBInitializer : DropCreateDatabaseIfModelChanges<InventoryManagementContext>
    {
        protected override void Seed(InventoryManagementContext context)
        {
            CreateDefaultLocations(context);
            CreateDefaultClientSites(context);
            CreateDefaultManufacturers(context);
            CreateDefaultModels(context);
            CreateDefaultProducts(context);

            //requires db to contain elements
            //CreateDefaultAssets(context);

            context.SaveChanges();

            base.Seed(context);
        }

        private void CreateDefaultAssets(InventoryManagementContext context)
        {
            IList<Asset> defaultAssets = new List<Asset>();

            defaultAssets.Add(new Asset()
                {
                    Product = new Product() {Name = "Printer" },
                    Manufacturer = new Manufacturer() {Name = "HP" },
                    Model = new Model() {Name = "LaserJet 2300" },
                    Location = new Location() { Name = "BHM" },
                    ClientSite = new ClientSite() { Name = "Lampo"},
                    SerialNumber = "X55321",
                    ItemName = "prdbhmadmin001"
                });

            foreach (var asset in defaultAssets)
            {
                context.Assets.Add(asset);
            }
        }

        private void CreateDefaultLocations(InventoryManagementContext context)
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

        }

        private void CreateDefaultClientSites(InventoryManagementContext context)
        {
            //create clientsites
            IList<ClientSite> defaultClientSites = new List<ClientSite>();

            defaultClientSites.Add(new ClientSite() { Name = "None" });
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

        }

        private void CreateDefaultProducts(InventoryManagementContext context)
        {
            //create clientsites
            IList<Product> defaultProducts = new List<Product>();

            defaultProducts.Add(new Product() { Name = "Printer" });
            defaultProducts.Add(new Product() { Name = "Laptop" });
            defaultProducts.Add(new Product() { Name = "Stapler" });
            defaultProducts.Add(new Product() { Name = "Desktop" });
            defaultProducts.Add(new Product() { Name = "Surface" });
            defaultProducts.Add(new Product() { Name = "Macbook" });
            defaultProducts.Add(new Product() { Name = "Smartphone" });

            foreach (var product in defaultProducts)
            {
                context.Products.Add(product);
            }

        }

        private void CreateDefaultManufacturers(InventoryManagementContext context)
        {
            //create clientsites
            IList<Manufacturer> defaultManufacturers = new List<Manufacturer>();

            defaultManufacturers.Add(new Manufacturer() { Name = "Dell" });
            defaultManufacturers.Add(new Manufacturer() { Name = "Apple" });
            defaultManufacturers.Add(new Manufacturer() { Name = "Staples" });
            defaultManufacturers.Add(new Manufacturer() { Name = "Microsoft" });
            defaultManufacturers.Add(new Manufacturer() { Name = "HP" });
            defaultManufacturers.Add(new Manufacturer() { Name = "LexMark" });
            defaultManufacturers.Add(new Manufacturer() { Name = "Samsung" });

            foreach (var manufacturer in defaultManufacturers)
            {
                context.Manufacturers.Add(manufacturer);
            }
        }

        private void CreateDefaultModels(InventoryManagementContext context)
        {
            //create clientsites
            IList<Model> defaultModels = new List<Model>();

            defaultModels.Add(new Model() { Name = "Macbook Pro" });
            defaultModels.Add(new Model() { Name = "Surface Pro 3" });
            defaultModels.Add(new Model() { Name = "Galaxy S5" });
            defaultModels.Add(new Model() { Name = "LaserJet 2000" });
            defaultModels.Add(new Model() { Name = "Dell Attitude 5111" });
            defaultModels.Add(new Model() { Name = "Staples 5100 Stapler" });
            defaultModels.Add(new Model() { Name = "FaxOFun" });

            foreach (var model in defaultModels)
            {
                context.Models.Add(model);
            }

        }

    }
}