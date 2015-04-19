using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace InventoryManagement_BT.Models
{
    public class Location : DbContext
    {

        public Location() : base("name=Location")
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
