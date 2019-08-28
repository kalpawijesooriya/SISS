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
        public int FullName { get; set; }
        public int RelationShip { get; set; }
        public int Addres { get; set; }
        public int NIC { get; set; }
        public int ContactNumber { get; set; }
        public int Discription { get; set; }
        [ForeignKey("SuspectID")]
        public Suspect Suspect { get; set; }
    }
}