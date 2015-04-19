namespace InventoryManagement_BT.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Product : DbContext
    {
        // Your context has been configured to use a 'Product' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'InventoryManagement_BT.Models.Product' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Product' 
        // connection string in the application configuration file.
        public Product()
            : base("name=Product")
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }

}