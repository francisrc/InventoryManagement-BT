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

        [HttpPost]
        public ActionResult TakeInventory(InventoryFormViewModel model)
        {
            //TODO: Validate the viewmodel
            if (ModelState.IsValid)
            {

                Asset item = repo.SearchInventory( model.ItemKey);
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
            return PartialView("_addInventory", new Asset());
        }

        [HttpPost]
        public ActionResult AddAsset(Asset a)
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

    }
}