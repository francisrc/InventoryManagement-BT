using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement_BT.Models
{
    public class SearchResultsViewModel
    {
        public string AssetTag { get; set; }
        public string Product { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Location { get; set; }
        public string InventoryOwner { get; set; }
    }
}