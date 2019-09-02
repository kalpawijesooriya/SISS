using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SISS.Models
{
    public class CrimeSuspects
    {
        [Key]
        public int SuspectID { get; set; }      
        public string FullName { get; set; }      
        public string Address { get; set; }     
        public string NIC { get; set; }   
        public string ContactNumber { get; set; }
        public string Status { get; set; }
        
        public int InvestigationId { get; set; }
        [ForeignKey("InvestigationId")]
        public Investigation Investigation { get; set; }

    }
}