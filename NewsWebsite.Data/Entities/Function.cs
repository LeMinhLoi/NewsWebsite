using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Entities
{
    public class Function
    {
        public int Id { get; set; }
        public string NameFunc { get; set; }
        public string Description { get; set; }     
        public List<RoleFunc> RoleFuncs { get; set; }
    }
}
