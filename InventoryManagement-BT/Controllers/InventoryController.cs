using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement_BT.Controllers
{
    public class InventoryController : Controller
    {
        // GET: TakeInventory
        public ActionResult TakeInventory()
        {
            return View();
        }
    }
}