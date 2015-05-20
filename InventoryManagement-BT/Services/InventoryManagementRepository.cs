using InventoryManagement_BT.DAL;
using InventoryManagement_BT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement_BT.Services
{
    public class InventoryManagementRepository
    {
        private InventoryManagementContext db = new InventoryManagementContext();

        private List<Location> locations;
        private List<ClientSite> clientSites;
        private List<Product> products;
        private List<Model> models;
        private List<Manufacturer> manufacturers;

        public InventoryManagementRepository()
        {

            locations = db.Locations.ToList();
            clientSites = db.ClientSites.ToList();
            products = db.Products.ToList();
            models = db.Models.ToList();
            manufacturers = db.Manufacturers.ToList();
        }

        public Asset SearchInventory(int? key)
        {
            if (key == null) return null;

            return db.Assets.Find(key);

        }

        public List<Location> GetLocations()
        {
            return locations;
        }

        public List<ClientSite> GetClientSites()
        {
            return clientSites;
        }

        public List<Asset> SearchViewInventory(SearchViewModel svm)
        {
            var stringProperties = typeof(Asset).GetProperties().Where(prop => prop.PropertyType == svm.KeywordSearch.GetType()).Select(x => x.ToString()).ToList();
            return db.Assets.Where(asset => stringProperties.Any(prop => prop == svm.KeywordSearch)).ToList();
        }

        public List<Product> GetProducts()
        {
            return products;
        }

        public List<Model> GetModels()
        {
            return models;
        }

        public List<Manufacturer> GetManufacturers()
        {
            return manufacturers;
        }


        public void CreateAsset(Asset a)
        {
            db.Assets.Add(a);
            db.SaveChanges();
        }
    }
}