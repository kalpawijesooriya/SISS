using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SISS.Models
{
    public class Investigation
    {
        [Key]
        public int InvestigationId { get; set; }
        public string InvestigationStartDate { get; set; }
        public string CrimeLocationInvestigationDetails { get; set; }
        public int CrimeId { get; set; }
        public string Status { get; set; }
        [ForeignKey("CrimeId")]
        public Crime Crime { get; set; }
     
    }
}