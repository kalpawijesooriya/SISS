using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SISS.Models
{
    public class SpecialReports
    {
        [Key]
        public int ReportID { get; set; }
        public string SpecialistName { get; set; }
        public string ReportType { get; set; }
        public string Designation { get; set; }
        public string Discription { get; set; }

        public int InvestigationId { get; set; }
        [ForeignKey("InvestigationId")]
        public Investigation Investigation { get; set; }
    }
}