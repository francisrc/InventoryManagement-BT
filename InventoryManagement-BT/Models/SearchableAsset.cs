namespace InventoryManagement_BT.Models
{
    public class SearchableAsset
    {
        public int AssetKey { get; set; }
        public string ClientSite { get; set; }
        public string InventoriedBy { get; set; }
        public string InventoryOwner { get; set; }
        public string ItemName { get; set; }
        public string Location { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Product { get; set; }
        public string SerialNumber { get; set; }
    }
}