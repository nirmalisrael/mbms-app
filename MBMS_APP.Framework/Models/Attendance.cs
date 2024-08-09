using System;

namespace MBMS_APP.Business.Models
{
    public class Attendance
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public short IsPresent { get; set; }
        public short IsLeave { get; set; }
    }
}
