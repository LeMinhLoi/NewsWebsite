using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Entities
{
    public class RoleFunc 
    {
        public int Id { get; set; }
        public int IdFunc { get; set; }
        public Function Function { get; set; }
        public Guid IdRole { get; set; }
        public WebRole Role { get; set; }
        public string Description { get; set; }
        public List<Permission> Permissions{ get; set; }

    }
}
