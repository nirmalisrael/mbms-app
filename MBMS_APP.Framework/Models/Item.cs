namespace MBMS_APP.Business.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int MeasurementId { get; set; }
        public string MeasurementName { get; set; }

        public Item(int itemId, string itemName, int measurementId)
        {
            ItemId = itemId;
            ItemName = itemName;
            MeasurementId = measurementId;
        }

        public Item() { }
    }
}
