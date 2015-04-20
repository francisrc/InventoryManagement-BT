using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement_BT.Models
{
    public class InventoryViewModel
    {
        public int ItemKey { get; set; }
        public string InventoryOwner { get; set; }
        public string InventoriedBy { get; set; }
        public string InventoryDate { get; set; }
    }
}