using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Entities
{
    public class CatalogInUser
    {   
        public int IdCatalog { get; set; }
        public Guid IdUser { get; set; }
        public Catalog Catalog { get; set; }
        public UserInfo UserInfo { get; set; }
    }
}
