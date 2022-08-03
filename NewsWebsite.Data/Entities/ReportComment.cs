using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Entities
{
    public class ReportComment
    {
        public int IDReportComment { get; set; }
        public int IdComment { get; set; }
        //public Comment Comment { get; set; }
        public string ContentReport { get; set; }
        public DateTime DateReport { get; set; }
        public Guid IdReporter { get; set; }
        public UserInfo Reporter { get; set; }
    }
}
