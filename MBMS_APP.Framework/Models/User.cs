using System;

namespace MBMS_APP.Business.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public short Gender { get; set; }
        public int OrganizationId{ get; set; }
        public short IsHostel { get; set; }
        public string PhoneNumber { get; set; }
        public string AadharNumber {  get; set; }
        public string Address {  get; set; }
        public int RoleId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public decimal Salary { get; set; }
        public bool IsStaffMember { get; set; }
    }
}

