using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SISS.Models
{
    public class Witnesses
    {

        [Key]
        public int WitnessId { get; set; }
        public String WitnessName { get; set; }
        public String WitnessNIC { get; set; }

        public String WitnessAddress { get; set; }
        public String WitnessTelephone { get; set; }
        public string WitnessDiscription { get; set; }
        public int InvestigationId { get; set; }
        [ForeignKey("InvestigationId")]
        public Investigation Investigation { get; set; }
    }
}