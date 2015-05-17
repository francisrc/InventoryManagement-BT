using InventoryManagement_BT.DAL;
using InventoryManagement_BT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagement_BT.Services
{
    public class InventoryManagementRepository
    {
        private InventoryManagementContext db = new InventoryManagementContext();

        private List<Location> locations;
        private List<ClientSite> clientSites;

        public InventoryManagementRepository()
        {

            locations = db.Locations.ToList();
            clientSites = db.ClientSites.ToList();
        }

        public Asset SearchInventory(int? key)
        {
            if (key == null) return null;

            Asset a = db.Assets.Find(key);
            if (a == null)
                return null;
            else
                return a;
        }

        public List<Location> GetLocations()
        {
            return locations;
        }

        public List<ClientSite> GetClientSites()
        {
            return clientSites;
        }


        public void CreateAsset(Asset a)
        {
            db.Assets.Add(a);
            db.SaveChanges();
        }
    }
}