namespace InventoryManagement_BT.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Manufacturer
    {
       
        public Manufacturer()  
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }

    }

}