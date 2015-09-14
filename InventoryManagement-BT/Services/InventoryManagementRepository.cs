﻿using InventoryManagement_BT.DAL;
using InventoryManagement_BT.Models;
using InventoryManagement_BT.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InventoryManagement_BT.Services
{
    public class InventoryManagementRepository
    {
        private readonly InventoryManagementContext _db = new InventoryManagementContext();

        private readonly List<Location> _locations;
        private readonly List<ClientSite> _clientSites;
        private readonly List<Product> _products;
        private readonly List<Model> _models;
        private readonly List<Manufacturer> _manufacturers;

        public InventoryManagementRepository()
        {
            //These aren't likely to change in our project so we generate our lists of these only once
            _locations = _db.Locations.ToList();
            _clientSites = _db.ClientSites.ToList();
            _products = _db.Products.ToList();
            _models = _db.Models.ToList();
            _manufacturers = _db.Manufacturers.ToList();
        }

        public Asset FindAssetByKey(int? key)
        {
            return key == null ? null : _db.Assets.DefaultIfEmpty().SingleOrDefault(a => a.AssetKey == key);
        }

        public List<Asset> GetAllAssets()
        {
            return _db.Assets.ToList();
        }

        public List<Location> GetLocations()
        {
            return _locations;
        }

        public List<ClientSite> GetClientSites()
        {
            return _clientSites;
        }

        public List<Asset> SearchAssets(SearchViewModel svm)
        {
            if (svm.KeywordSearch == null)
            {
                return null;
            }

            var properties = typeof(SearchableAsset).GetProperties().Where(prop => prop.PropertyType == svm.KeywordSearch.GetType());

            var wildcardMatches = _db.Assets.AsEnumerable().Where(asset => properties.Any(prop => ((prop.GetValue(asset.ConvertToSearchable(), null) == null) ? "" : prop.GetValue(asset.ConvertToSearchable(), null).ToString().ToLower()).Contains(svm.KeywordSearch.ToLower()))).ToList();
            return wildcardMatches;
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public List<Model> GetModels()
        {
            return _models;
        }

        public List<Manufacturer> GetManufacturers()
        {
            return _manufacturers;
        }

        public Asset FindBySearchQuery(InventoryFormViewModel model)
        {
            return _db.Assets
                .DefaultIfEmpty()
                .Where(a => a.AssetKey == model.ItemKey)
                .Where(a => a.InventoryOwner == model.InventoryOwner)
                .Where(a => a.ClientSite.Id == model.SelectedClientSiteId)
                .SingleOrDefault(a => a.Location.Id == model.SelectedLocationId);
        }

        public void CreateAsset(Asset a)
        {
            _db.Assets.Add(a);
            _db.SaveChanges();
        }

        public Product GetProductById(int selectedProductId)
        {
            return _db.Products.Find(selectedProductId);
        }

        public void UpdateAsset(Asset newAsset)
        {
            var oldAsset = _db.Assets.Find(newAsset.AssetKey);

            //creating a new asset
            if (oldAsset == null)
            {
                _db.Assets.Add(newAsset);
            }
            else
            {
                oldAsset.UpdateProperties(newAsset);
                _db.Entry(oldAsset).State = EntityState.Modified;

            }
            _db.SaveChanges();
        }

        public Manufacturer GetManufacturerById(int selectedManufacturerId)
        {
            return _db.Manufacturers.Find(selectedManufacturerId);
        }

        public Model GetModelById(int selectedModelId)
        {
            return _db.Models.Find(selectedModelId);
        }

        public Location GetLocationById(int selectedLocationId)
        {
            return _db.Locations.Find(selectedLocationId);
        }

        public ClientSite GetClientSiteById(int selectedClientSiteId)
        {
            return _db.ClientSites.Find(selectedClientSiteId);
        }
    }
}