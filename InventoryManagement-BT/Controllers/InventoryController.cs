using InventoryManagement_BT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement_BT.Controllers
{
    public class InventoryController : Controller
    {
        // GET: /inventorymanagement/TakeInventory
        [HttpGet]
        public ActionResult TakeInventory()
        {
            InventoryViewModel inv = new InventoryViewModel();
            return View(inv);
        }

        // POST: /inventorymanagement/TakeInventory
        [HttpPost]
        public ActionResult TakeInventory(InventoryViewModel invVM)
        {
            return View();
        }



        //GET /inventoryManagement/ViewInventory
        public ActionResult ViewInventory()
        {
            return View();
        }
    }
}