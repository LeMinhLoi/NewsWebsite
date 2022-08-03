using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Entities
{
    public class NewsInCatalog
    {
        public int IdCatalog { get; set; }
        public Guid IdNews { get; set; }
        public Catalog Catalog { get; set; }
        public News News { get; set; }
    }
}
