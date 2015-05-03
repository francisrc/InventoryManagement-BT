using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement_BT.Models
{
    public class InventoryFormViewModel
    {
        public List<Location> Locations { get; set; }


        public InventoryFormViewModel()
        {
            InventoryDate = DateTime.UtcNow.ToString("MM/DD/yyyy");
        }

        public int? ItemKey { get; set; }
        public string InventoryOwner { get; set; }

        [Display(Name = "Location")]
        public int SelectedLocationId { get; set; }

        public IEnumerable<SelectListItem> LocationItems
        {
            get { return new SelectList(Locations, "Id", "Name"); }
        }

        //Has to come from the currently signed in user
        public string InventoriedBy { get; set; }

        //All dates should be formatted as "MM/DD/YYYY"
        public string InventoryDate { get; set; }
    }
}