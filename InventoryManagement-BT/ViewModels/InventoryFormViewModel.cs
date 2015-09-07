using InventoryManagement_BT.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace InventoryManagement_BT.ViewModels
{
    public class InventoryFormViewModel
    {

        [Display(Name = "Item")]
        [Range(1, 999999)]
        [Required]
        public int? ItemKey { get; set; }

        public List<Location> Locations { get; set; }
        public List<ClientSite> ClientSites { get; set; }

        [Display(Name = "Inventoried By")]
        [StringLength(64, MinimumLength = 6)]
        public string InventoriedBy { get; set; }

        [Required]
        public string InventoryDate { get; set; }

        [Display(Name = "Inventory Owner")]
        [StringLength(64)]
        [Required]
        public string InventoryOwner { get; set; }



        [Display(Name = "Location")]
        public int SelectedLocationId { get; set; }

        public IEnumerable<SelectListItem> LocationItems => new SelectList(Locations, "Id", "Name");

        [Display(Name = "Client Site")]
        public int SelectedClientSiteId { get; set; }

        public IEnumerable<SelectListItem> ClientSiteItems => new SelectList(ClientSites, "Id", "Name");
    }
}