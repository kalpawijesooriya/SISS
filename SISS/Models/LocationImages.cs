using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SISS.Models
{
    public class LocationImages
    {


        [Key]
        public int LocationImageId { get; set; }
        public string LocationimagePath { get; set; }
        public int InvestigationId { get; set; }
        [ForeignKey("InvestigationId")]
        public Investigation Investigation { get; set; }
    }
}