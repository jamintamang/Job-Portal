﻿using Microsoft.AspNetCore.Identity;
using System.Security;

namespace JobPortal.web.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; }
        public String MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string UserRoleId { get; set; }
        public string ProfileUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

    }
}
