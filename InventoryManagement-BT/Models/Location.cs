using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace InventoryManagement_BT.Models
{
    public class Location
    {

        public Location()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
