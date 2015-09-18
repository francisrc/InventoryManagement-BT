using InventoryManagement_BT.Models;
using InventoryManagement_BT.ViewModels;
using InventoryManagement_BT.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PagedList;

namespace InventoryManagement_BT.Controllers
{
    public class AssetController : Controller
    {
        private readonly InventoryManagementRepository _repo = new InventoryManagementRepository();
        private const int PageSize = 3;

        public ViewResult Index(int? page)
        {
            var assets = _repo.GetAllAssets();

            var pageNumber = (page ?? 1);

            return View(assets.ToPagedList(pageNumber, PageSize));
        }

        // GET: TakeInventory
        [HttpGet]
        public ViewResult TakeInventory()
        {
            var ivvm = new InventoryFormViewModel
            {
                Locations = _repo.GetLocations(),
                ClientSites = _repo.GetClientSites(),
                InventoryDate = DateTime.Now.ToString("MM/dd/yyyy"),
                InventoriedBy = "Robert Newton"
            };

            //Default used since we don't have AD connected

            return View(ivvm);
        }

        [HttpPost]
        public PartialViewResult TakeInventory(InventoryFormViewModel model)
        {

            if (ModelState.IsValid)
            {
                var item = _repo.FindBySearchQuery(model);

                if (item != null && DateTime.Now.AddDays(-90) < item.InventoryDate)
                {
                    ModelState.AddModelError("InventoryDate", "Possible Duplicate Item");
                }

                ViewBag.ItemKey = model.ItemKey;
                ViewBag.InventoryOwner = model.InventoryOwner;
                ViewBag.InventoriedBy = "Robert Newton"; //Default used since we don't have AD connected

                return PartialView("_searchResults", item);
            }

            Response.StatusCode = 404;
            model.Locations = _repo.GetLocations();
            model.ClientSites = _repo.GetClientSites();
            return PartialView("_takeInventoryForm", model);
        }

        [HttpGet]
        public ViewResult ViewInventory()
        {
            var svm = new SearchViewModel
            {
                Locations = _repo.GetLocations(),
                ClientSites = _repo.GetClientSites()
            };

            return View(svm);
        }

        [HttpPost]
        public PartialViewResult SearchInventory(SearchViewModel svm)
        {

            if (!ModelState.IsValid)
            {
                svm.Locations = _repo.GetLocations();
                svm.ClientSites = _repo.GetClientSites();

                Response.StatusCode = 404;
                return PartialView("_searchInventoryForm", svm);
            }

            var searchResults = new List<SearchResultsViewModel>();
            if (svm.KeywordSearch != null)
            {
                var assets = _repo.SearchAssets(svm);
                searchResults.AddRange(assets.Select(asset => new SearchResultsViewModel()
                {
                    AssetTag = asset.AssetKey, Product = asset.Product.Name, Manufacturer = asset.Manufacturer.Name, Model = asset.Model.Name, Location = asset.Location.Name, InventoryOwner = asset.InventoryOwner
                }));
            }
            return PartialView("_viewInventorySearchResults", searchResults);
        }

        [HttpGet]
        public PartialViewResult EditAsset(int assetKey)
        {
            var a= _repo.FindAssetByKey(assetKey);
            var afvm = new AssetFormViewModel
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
                SelectedLocationId = a.Location.Id,
                Manufacturers = _repo.GetManufacturers(),
                Models = _repo.GetModels(),
                Locations = _repo.GetLocations(),
                ClientSites = _repo.GetClientSites(),
                Products = _repo.GetProducts()
            };

            ViewBag.ModalName = "Edit";

            return PartialView("_modifyAsset", afvm);
        }

        [HttpGet]
        public PartialViewResult AddAsset(string assetKey = "", string inventoryOwner = "")
        {
            var avm = new AssetFormViewModel
            {
                AssetTag = assetKey,
                InventoryOwner = inventoryOwner,
                Manufacturers = _repo.GetManufacturers(),
                Models = _repo.GetModels(),
                Locations = _repo.GetLocations(),
                ClientSites = _repo.GetClientSites(),
                Products = _repo.GetProducts()
            };


            ViewBag.ModalName = "Add";


            return PartialView("_modifyAsset", avm);
        }

        [HttpPost]
        public PartialViewResult UpdateAsset(AssetFormViewModel avm)
        {
            avm.Manufacturers = _repo.GetManufacturers();
            avm.Models = _repo.GetModels();
            avm.Locations = _repo.GetLocations();
            avm.ClientSites = _repo.GetClientSites();
            avm.Products = _repo.GetProducts();

            if (ModelState.IsValid)
            {
                Response.StatusCode = 200;
                var a = new Asset
                {
                    Product = _repo.GetProductById(avm.SelectedProductId),
                    Manufacturer = _repo.GetManufacturerById(avm.SelectedManufacturerId),
                    Model = _repo.GetModelById(avm.SelectedModelId),
                    Location = _repo.GetLocationById(avm.SelectedLocationId),
                    ClientSite = _repo.GetClientSiteById(avm.SelectedClientSiteId),
                    AssetKey = int.Parse(avm.AssetTag),
                    SerialNumber = avm.SerialNumber,
                    ItemName = avm.ItemName,
                    InventoryOwner = avm.InventoryOwner,
                    InventoriedBy = avm.InventoriedBy,
                    InventoryDate = avm.InventoryDate,
                    IsDisposed = avm.IsDisposed
                };
                _repo.UpdateAsset(a);
                return PartialView("_modifyAsset", avm);
            }

            Response.StatusCode = 422;
            return PartialView("_updateAssetForm", avm);
        }

        [HttpGet]
        public ActionResult UpdateOwnerAndDate(string assetKey = "", string date = "", string inventoriedBy = "")
        {
            var asset = _repo.FindAssetByKey(int.Parse(assetKey));
            asset.InventoryDate = DateTime.Parse(date);
            asset.InventoriedBy = inventoriedBy;

            _repo.UpdateAsset(asset);

            return RedirectToAction("TakeInventory");
        }

    }
}