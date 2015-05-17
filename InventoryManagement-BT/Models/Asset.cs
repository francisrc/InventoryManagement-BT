namespace InventoryManagement_BT.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Asset
    {
        public Asset() {
            PurchaseDate = DateTime.UtcNow;
            InventoryDate = DateTime.UtcNow;

        
        }

        [Key]
        [Required]
        [Display(Name = "Asset Tag")]
        public int AssetKey { get; set; }

        [MaxLength(64)]
        [Display(Name = "Serial Number")]
        public string SerialNumber { get; set; }

        [MaxLength(64)]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }

        [Display(Name = "Purchase Date")]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }

        [Required]
        [MaxLength(64)]
        [Display(Name = "Inventory Owner")]
        public string InventoryOwner { get; set; }

        [Display(Name = "Inventoried By")]
        public string InventoriedBy { get; set; }

        [Display(Name = "Inventory Date")]
        [DataType(DataType.Date)]
        public DateTime InventoryDate  { get; set; }

        [Display(Name = "Is Disposed")]
        public bool IsDisposed { get; set; }

        //Associations
        public virtual Product Product { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Model Model { get; set; }
        public virtual Location Location { get; set; }
        public virtual ClientSite ClientSite { get; set; }

    }

}