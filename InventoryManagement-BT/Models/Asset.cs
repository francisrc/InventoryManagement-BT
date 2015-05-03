namespace InventoryManagement_BT.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Asset
    {
        public Asset()
        {
        }

        [Key]
        public int AssetKey { get; set; }

        [MaxLength(64)]
        public string SerialNumber { get; set; }

        [MaxLength(64)]
        public string ItemName { get; set; }

        public string PurchaseDate { get; set; }

        [Required]
        [MaxLength(64)]
        public string InventoryOwner { get; set; }

        public string InventoriedBy { get; set; }
        public string InventoryDate  { get; set; }
        public bool IsDisposed { get; set; }

        //Associations
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Manufacturer> Manufacturers { get; set; }
        public virtual ICollection<Model> Models { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual ICollection<ClientSite> ClientSites { get; set; }

    }

}