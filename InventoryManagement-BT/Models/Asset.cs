using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement_BT.Models
{
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
                AssetKey = AssetKey,
                SerialNumber = SerialNumber,
                ItemName = ItemName,
                InventoryOwner = InventoryOwner,
                InventoriedBy = InventoriedBy,
                Product = Product.Name,
                Manufacturer = Manufacturer.Name,
                Model = Model.Name,
                Location = Location.Name,
                ClientSite = ClientSite.Name
            };
        }

        /// <summary>
        /// Update all properties of this Asset with that new asset
        /// </summary>
        /// <param name="newAsset"></param>
        public void UpdateProperties(Asset newAsset)
        {
            SerialNumber = newAsset.SerialNumber;
            PurchaseDate = newAsset.PurchaseDate;
            ItemName = newAsset.ItemName;
            ClientSite = newAsset.ClientSite;
            Product = newAsset.Product;
            Model = newAsset.Model;
            Manufacturer = newAsset.Manufacturer;
            PurchaseDate = newAsset.PurchaseDate;
            InventoriedBy = newAsset.InventoriedBy;
            InventoryDate = newAsset.InventoryDate;
            IsDisposed = newAsset.IsDisposed;
            Location = newAsset.Location;
        }
    }

}