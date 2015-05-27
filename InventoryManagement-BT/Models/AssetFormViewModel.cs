using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagement_BT.Models
{
    public class AssetFormViewModel
    {
        public AssetFormViewModel()
        {
            PurchaseDate = DateTime.UtcNow;
            InventoryDate = DateTime.UtcNow;
        }


        [Key]
        [Required]
        [Display(Name = "Asset Tag")]
        public string AssetTag { get; set; }

        [Display(Name = "Serial Number")]
        [StringLength(64)]
        public string SerialNumber { get; set; }

        [Display(Name = "Item Name")]
        [StringLength(64)]
        public string ItemName { get; set; }

        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Inventory Date")]
        public DateTime InventoryDate { get; set; }

        [Display(Name = "Inventory Owner")]
        [Required]
        [StringLength(64)]
        public string InventoryOwner { get; set; }

        [Display(Name = "Inventoried By")]
        [StringLength(64, MinimumLength = 6)]
        public string InventoriedBy { get; set; }

        [Display(Name = "Is Disposed")]
        public bool IsDisposed { get; set; }

        public bool IsReadOnly
        {
            get
            {
                return (this.AssetTag == null);
            }
        }



        public List<Location> Locations { get; set; }
        public List<ClientSite> ClientSites { get; set; }
        public List<Product> Products { get; set; }
        public List<Model> Models { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }


        [Display(Name = "Location")]
        public int SelectedLocationId { get; set; }

        public IEnumerable<SelectListItem> LocationItems
        {
            get { return new SelectList(Locations, "Id", "Name"); }
        }

        [Display(Name = "Client Site")]
        public int SelectedClientSiteId { get; set; }

        public IEnumerable<SelectListItem> ClientSiteItems
        {
            get { return new SelectList(ClientSites, "Id", "Name"); }
        }

        [Display(Name = "Product")]
        public int SelectedProductId { get; set; }

        public IEnumerable<SelectListItem> ProductItems
        {
            get { return new SelectList(Products, "Id", "Name"); }
        }

        [Display(Name = "Manufacturer")]
        public int SelectedManufacturerId { get; set; }

        public IEnumerable<SelectListItem> ManufacturerItems
        {
            get { return new SelectList(Manufacturers, "Id", "Name"); }
        }

        [Display(Name = "Model")]
        public int SelectedModelId { get; set; }

        public IEnumerable<SelectListItem> ModelItems
        {
            get { return new SelectList(Models, "Id", "Name"); }
        }

    }
}