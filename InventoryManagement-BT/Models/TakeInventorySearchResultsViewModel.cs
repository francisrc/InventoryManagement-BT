using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement_BT.Models
{
    public class TakeInventorySearchResultsViewModel
    {
        public int AssetTag { get; set; }
        public string Product { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public string ItemName { get; set; }
        public string LastInventoryDate { get; set; }
    }
}