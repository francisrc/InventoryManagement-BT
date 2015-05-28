namespace InventoryManagement_BT.Models
{
    public class SearchResultsViewModel
    {
        public int AssetTag { get; set; }
        public string Product { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Location { get; set; }
        public string InventoryOwner { get; set; }
    }
}