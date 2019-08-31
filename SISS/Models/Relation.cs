using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SISS.Models
{
    public class Relation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RelationID { get; set; }
        public string FullName { get; set; }
        public string RelationShip { get; set; }
        public string Addres { get; set; }
        public string NIC { get; set; }
        public int ContactNumber { get; set; }
        public string Discription { get; set; }
        public int SuspectID { get; set; }
        [ForeignKey("SuspectID")]
        public Suspect Suspect { get; set; }
    }
}