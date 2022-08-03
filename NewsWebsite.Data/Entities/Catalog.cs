using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Entities
{
    public class Catalog
    {
        public int IdCatalog { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CatalogInUser> CatalogInUsers { get; set; }
        public List<NewsInCatalog> NewsInCatalogs{ get; set; }

    }
}
