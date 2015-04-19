namespace InventoryManagement_BT.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Manufacturer : DbContext
    {
        // Your context has been configured to use a 'Manufacturer' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'InventoryManagement_BT.Models.Manufacturer' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Manufacturer' 
        // connection string in the application configuration file.
        public Manufacturer()
            : base("name=Manufacturer")
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }

    }

}