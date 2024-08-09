namespace MBMS_APP.Business.Models
{
    public class PurchaseRequest
    {
        public int RequestId { get; set; }
        public string RequestName { get; set; }
        public int NoOfItems { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public double Amount { get; set; }
        public short IsDirectExpense { get; set; }
    }
}
