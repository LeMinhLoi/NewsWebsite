using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Entities
{
    public class Permission
    {
        public Guid IdUser { get; set; }
        public UserInfo UserInfo { get; set; }
        public int IdRoleFunc { get; set; }
        public RoleFunc RoleFunc { get; set; }
    }
}
