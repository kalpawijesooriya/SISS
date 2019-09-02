using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SISS.Models
{
    public class CrimeOfficer
    {
        [Key]
        public int CrimeOfficerId { get; set; }
        public string UserEmployeeNumber { get; set; }
        public int CrimeId { get; set; }
        public int oder { get; set; }
        [ForeignKey("UserEmployeeNumber")]
        public User User { get; set; }
        [ForeignKey("CrimeId")]
        public Crime Crime { get; set; }

    }
}