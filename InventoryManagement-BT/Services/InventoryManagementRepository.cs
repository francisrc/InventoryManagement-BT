using InventoryManagement_BT.DAL;
using InventoryManagement_BT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            //These aren't likely to change in our project so we generate our lists of these only once
            locations = db.Locations.ToList();
            clientSites = db.ClientSites.ToList();
            products = db.Products.ToList();
            models = db.Models.ToList();
            manufacturers = db.Manufacturers.ToList();
        }

        public Asset FindAssetByKey(int? key)
        {
            if (key == null) return null;
            return db.Assets.DefaultIfEmpty().SingleOrDefault(a => a.AssetKey == key);

        }

        public List<Asset> GetAssets()
        {
            return db.Assets.ToList();
        }

        public List<Location> GetLocations()
        {
            return locations;
        }

        public List<ClientSite> GetClientSites()
        {
            return clientSites;
        }

        public List<Asset> SearchAssets(SearchViewModel svm)
        {
            var properties = typeof(SearchableAsset).GetProperties().Where(prop => prop.PropertyType == svm.KeywordSearch.GetType());

            List<Asset> wildcardMatches = db.Assets.AsEnumerable().Where(asset => properties.Any(prop => ((prop.GetValue(asset.ConvertToSearchable(), null) == null) ? "" : prop.GetValue(asset.ConvertToSearchable(), null).ToString()).Contains(svm.KeywordSearch))).ToList();
            return wildcardMatches;
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

        public Asset FindBySearchQuery(InventoryFormViewModel model)
        {
            return db.Assets.DefaultIfEmpty()
                .Where(a => a.AssetKey == model.ItemKey)
                .Where(a => a.InventoryOwner == model.InventoryOwner)
                .Where(a => a.ClientSite.Id == model.SelectedClientSiteId)
                .Where(a => a.Location.Id == model.SelectedLocationId)
                .SingleOrDefault();
        }

        public void CreateAsset(Asset a)
        {
            db.Assets.Add(a);
            db.SaveChanges();
        }

        public Product GetProductById(int selectedProductId)
        {
            return db.Products.Find(selectedProductId);
        }

        public void UpdateAsset(Asset newAsset)
        {
            var oldAsset = db.Assets.Find(newAsset.AssetKey);

            //creating a new asset
            if (oldAsset == null)
            {
                db.Assets.Add(newAsset);
            }
            else
            {
                oldAsset.UpdateProperties(newAsset);
                db.Entry(oldAsset).State = EntityState.Modified;

            }
            db.SaveChanges();
        }

        public Manufacturer GetManufacturerById(int selectedManufacturerId)
        {
            return db.Manufacturers.Find(selectedManufacturerId);
        }

        public Model GetModelById(int selectedModelId)
        {
            return db.Models.Find(selectedModelId);
        }

        public Location GetLocationById(int selectedLocationId)
        {
            return db.Locations.Find(selectedLocationId);
        }

        public ClientSite GetClientSiteById(int selectedClientSiteId)
        {
            return db.ClientSites.Find(selectedClientSiteId);
        }
    }
}