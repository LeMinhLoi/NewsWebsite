using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Entities
{
    public class WebRole : IdentityRole<Guid>
    {
        public string Description { get; set; }
        public List<RoleFunc> RoleFuncs { get; set; }
    }
}
