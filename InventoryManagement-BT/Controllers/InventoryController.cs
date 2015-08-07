using InventoryManagement_BT.Models;
using InventoryManagement_BT.ViewModels;
using InventoryManagement_BT.Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace InventoryManagement_BT.Controllers
{
    public class InventoryController : Controller
    {
        private InventoryManagementRepository repo = new InventoryManagementRepository();

        public ActionResult Index()
        {
            List<Asset> assets = repo.GetAssets();
            return View(assets);
        }

        // GET: TakeInventory
        [HttpGet]
        public ActionResult TakeInventory()
        {
            InventoryFormViewModel ivvm = new InventoryFormViewModel();
            ivvm.Locations = repo.GetLocations();
            ivvm.ClientSites = repo.GetClientSites();

            ivvm.InventoryDate = DateTime.Now.ToString("MM/dd/yyyy");
            ivvm.InventoriedBy = "Robert Newton"; //Default used since we don't have AD connected

            return View(ivvm);
        }

        [HttpPost]
        public ActionResult TakeInventory(InventoryFormViewModel model)
        {

            if (ModelState.IsValid)
            {

                Asset item = repo.FindBySearchQuery(model);

                if (item != null && DateTime.Now.AddDays(-90) < item.InventoryDate)
                {
                    ModelState.AddModelError("InventoryDate", "Possible Duplicate Item");
                }

                ViewBag.ItemKey = model.ItemKey;
                return PartialView("_searchResults", item);
            }
            model.Locations = repo.GetLocations();
            model.ClientSites = repo.GetClientSites();
            return View("TakeInventory", model);
        }

        [HttpGet]
        public ActionResult ViewInventory()
        {
            SearchViewModel svm = new SearchViewModel();
            svm.Locations = repo.GetLocations();
            svm.ClientSites = repo.GetClientSites();

            return View(svm);
        }

        [HttpPost]
        public ActionResult SearchInventory(SearchViewModel svm)
        {
            if (ModelState.IsValid)
            {
                List<Asset> assets = repo.SearchAssets(svm);
                List<SearchResultsViewModel> searchResults = new List<SearchResultsViewModel>();
                foreach (var asset in assets)
                {
                    searchResults.Add(new SearchResultsViewModel()
                    {
                        AssetTag = asset.AssetKey,
                        Product = asset.Product.Name,
                        Manufacturer = asset.Manufacturer.Name,
                        Model = asset.Model.Name,
                        Location = asset.Location.Name,
                        InventoryOwner = asset.InventoryOwner
                    });
                }
                return PartialView("_viewInventorySearchResults", searchResults);

            }
            return View(svm);
        }




        [HttpGet]
        public PartialViewResult EditAsset(int assetKey)
        {
            Asset a = repo.FindAssetByKey(assetKey);
            AssetFormViewModel afvm = new AssetFormViewModel
            {
                AssetTag = a.AssetKey.ToString(),
                ItemName = a.ItemName,
                SerialNumber = a.SerialNumber,
                InventoriedBy = a.InventoriedBy,
                InventoryOwner = a.InventoryOwner,
                PurchaseDate = a.PurchaseDate,
                IsDisposed = a.IsDisposed,
                InventoryDate = a.InventoryDate,
                SelectedManufacturerId = a.Manufacturer.Id,
                SelectedModelId = a.Model.Id,
                SelectedProductId = a.Product.Id,
                SelectedClientSiteId = a.ClientSite.Id,
                SelectedLocationId = a.Location.Id
            };

            afvm.Manufacturers = repo.GetManufacturers();
            afvm.Models = repo.GetModels();
            afvm.Locations = repo.GetLocations();
            afvm.ClientSites = repo.GetClientSites();
            afvm.Products = repo.GetProducts();

            return PartialView("_modifyAsset", afvm);
        }




        [HttpGet]
        public PartialViewResult AddAsset(string assetKey = "", string inventoryOwner = "")
        {
            AssetFormViewModel avm = new AssetFormViewModel();

            avm.AssetTag = assetKey;
            avm.InventoryOwner = inventoryOwner;
            avm.Manufacturers = repo.GetManufacturers();
            avm.Models = repo.GetModels();
            avm.Locations = repo.GetLocations();
            avm.ClientSites = repo.GetClientSites();
            avm.Products = repo.GetProducts();


            return PartialView("_modifyAsset", avm);
        }

        [HttpPost]
        public ActionResult UpdateAsset(AssetFormViewModel avm)
        {
            if (ModelState.IsValid)
            {
                Response.StatusCode = 200;
                Asset a = new Asset
                {
                    Product = repo.GetProductById(avm.SelectedProductId),
                    Manufacturer = repo.GetManufacturerById(avm.SelectedManufacturerId),
                    Model = repo.GetModelById(avm.SelectedModelId),
                    Location = repo.GetLocationById(avm.SelectedLocationId),
                    ClientSite = repo.GetClientSiteById(avm.SelectedClientSiteId),
                    AssetKey = int.Parse(avm.AssetTag),
                    SerialNumber = avm.SerialNumber,
                    ItemName = avm.ItemName,
                    InventoryOwner = avm.InventoryOwner,
                    InventoriedBy = avm.InventoriedBy,
                    InventoryDate = avm.InventoryDate,
                    IsDisposed = avm.IsDisposed
                };
                repo.UpdateAsset(a);
            }
            else
            {
                Response.StatusCode = 422;
            }

            avm.Manufacturers = repo.GetManufacturers();
            avm.Models = repo.GetModels();
            avm.Locations = repo.GetLocations();
            avm.ClientSites = repo.GetClientSites();
            avm.Products = repo.GetProducts();

            return PartialView("_modifyAsset", avm);
        }


    }
}