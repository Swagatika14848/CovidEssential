using System;
using System.Collections.Generic;

#nullable disable

namespace E_CommerceClient.Models
{
    public partial class UserDetail
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
        public string UserContact { get; set; }
        public string UserAddress { get; set; }
        public int? RoleId { get; set; }

        public virtual UserRole Role { get; set; }
    }
}
