using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace InventoryManagement_BT.Models
{
    public class ClientSite : DbContext

    {
        public ClientSite(): base("name=ClientSite")
        {
        }

        public int Id { get; set; }
        public int Name { get; set; }
    }
}
