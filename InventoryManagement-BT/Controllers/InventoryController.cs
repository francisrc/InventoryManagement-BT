using InventoryManagement_BT.DAL;
using InventoryManagement_BT.Models;
using InventoryManagement_BT.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement_BT.Controllers
{
    public class InventoryController : Controller
    {
        private InventoryManagementRepository repo = new InventoryManagementRepository();

        // GET: TakeInventory
        [HttpGet]
        public ActionResult TakeInventory()
        {
            InventoryFormViewModel ivvm = new InventoryFormViewModel();
            ivvm.Locations = repo.GetLocations();
            ivvm.ClientSites = repo.GetClientSites();

            return View(ivvm);
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
        public ActionResult TakeInventory(InventoryFormViewModel model)
        {
            //TODO: Validate the viewmodel
            if (ModelState.IsValid)
            {

                Asset item = repo.SearchInventory(model.ItemKey);
                ViewBag.ItemKey = model.ItemKey;
                if (item == null)
                {
                    return PartialView("_searchResults", null);
                }
                else
                {
                    return PartialView("_searchResults", item);
                }
            }

            return RedirectToAction("TakeInventory");
        }

        [HttpGet]
        public PartialViewResult AddAsset()
        {
            ViewBag.Products = CreateSelectListItem<Product>(repo.GetProducts());

            /*
            ViewBag.Manufacturers = repo.GetManufacturers();
            ViewBag.Models = repo.GetModels();
            ViewBag.Locations = repo.GetLocations();
            ViewBag.ClientSites = repo.GetClientSites();
             */

            return PartialView("_addInventory", new Asset());
        }

        [HttpPost]
        public ActionResult AddAsset(Asset a, Product p)
        {
            if (ModelState.IsValid)
            {
                repo.CreateAsset(a);
                Response.StatusCode = 200;
            }
            else
            {
                Response.StatusCode = 422;
            }
            return PartialView("_addInventory", a);
        }

        private SelectList CreateSelectListItem<T>(List<T> products)
        {
            return new SelectList(products, "Id", "Name");
        }

    }
}