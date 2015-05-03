﻿using InventoryManagement_BT.DAL;
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

        public void TakeInventory(InventoryFormViewModel model)
        {
            Asset a = db.Assets.Find(model.ItemKey);

        }

        //TODO: Store the List of Locations so we don't make multiple calls
        public List<Location> GetLocations()
        {
            return locations;
        }

        public List<ClientSite> GetClientSites()
        {
            return clientSites;
        }

    }
}