using InventoryManagement_BT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement_BT.ViewModels
{
    public class SearchViewModel
    {

        public string KeywordSearch { get; set; }

        [Range(0, 999999)]
        public int? Item { get; set; }

        public List<Location> Locations { get; set; }
        public List<ClientSite> ClientSites { get; set; }

        [Display(Name = "Location")]
        public int SelectedLocationId { get; set; }

        public IEnumerable<SelectListItem> LocationItems => new SelectList(Locations, "Id", "Name");

        [Display(Name = "Client Site")]
        public int SelectedClientSiteId { get; set; }

        public IEnumerable<SelectListItem> ClientSiteItems => new SelectList(ClientSites, "Id", "Name");
    }
}