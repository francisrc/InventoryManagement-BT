namespace InventoryManagement_BT.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class Product
    {

        public Product()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }

    }

}