using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Entities
{
    public class IdentityUser
    {
        public int Id { get; set; }
        public string Account { get; set; }
        public string HashPassword { get; set; }
        public int IdRole { get; set; }
    }
}
