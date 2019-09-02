using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SISS.Models
{
    public class InvestigationResults
    {
        [Key]
        public int ResultID { get; set; }
        public string CourtDecision { get; set; }
        public string Punishment { get; set; }
        public string Note { get; set; }

        public int InvestigationId { get; set; }
        [ForeignKey("InvestigationId")]
        public Investigation Investigation { get; set; }
    }
}