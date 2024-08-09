namespace MBMS_APP.Business.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public Status(int statusId, string statusName)
        {
            StatusId = statusId;
            StatusName = statusName;
        }

        public Status() { }
    }
}
