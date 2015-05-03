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
            return View(ivvm);
        }

        [HttpPost]
        public ActionResult TakeInventory(InventoryFormViewModel model)
        {
            //TODO: Validate the viewmodel
            if (ModelState.IsValid)
            {
                repo.TakeInventory(model);
            }
            return View();
        }


    }
}