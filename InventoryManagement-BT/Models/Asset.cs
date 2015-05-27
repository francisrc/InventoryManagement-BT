namespace InventoryManagement_BT.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Asset
    {
        public Asset() {
            PurchaseDate = DateTime.UtcNow;
            InventoryDate = DateTime.UtcNow;
        }

        [Key]
        [Required]
        [Display(Name = "Asset Tag")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        public SearchableAsset ConvertToSearchable()
        {
            return new SearchableAsset
            {
                AssetKey = this.AssetKey,
                SerialNumber = this.SerialNumber,
                ItemName = this.ItemName,
                InventoryOwner = this.InventoryOwner,
                InventoriedBy = this.InventoriedBy,
                Product = this.Product.Name,
                Manufacturer = this.Manufacturer.Name,
                Model = this.Model.Name,
                Location = this.Location.Name,
                ClientSite = this.ClientSite.Name
            };
        }

        /// <summary>
        /// Update all properties of this Asset with that new asset
        /// </summary>
        /// <param name="newAsset"></param>
        public void UpdateProperties(Asset newAsset)
        {
            this.SerialNumber = newAsset.SerialNumber;
            this.PurchaseDate = newAsset.PurchaseDate;
            this.ItemName = newAsset.ItemName;
            this.ClientSite = newAsset.ClientSite;
            this.Product = newAsset.Product;
            this.Model = newAsset.Model;
            this.Manufacturer = newAsset.Manufacturer;
            this.PurchaseDate = newAsset.PurchaseDate;
            this.InventoriedBy = newAsset.InventoriedBy;
            this.InventoryDate = newAsset.InventoryDate;
            this.IsDisposed = newAsset.IsDisposed;
            this.Location = newAsset.Location;
        }
    }

}