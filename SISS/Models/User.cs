using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SISS.Models
{
    public class User
    {
        [Key]
        [ForeignKey("Login")]
        public int UserEmployeeNumber { get; set; }
        [Required(ErrorMessage = "Plese Fill iths Filed")]
        public string officerName { get; set; }
        [Required(ErrorMessage = "Plese Fill this Filed")]
        public string officerFullName { get; set; }
        [Required(ErrorMessage = "Plese Fill this Filed")]
        public string officerBirthday { get; set; }
        [Required(ErrorMessage = "Plese Fill this Filed")]
        public string officerPoliceStation { get; set; }
        [Required(ErrorMessage = "Plese Fill this Filed")]
        public string officerMarrageStatus { get; set; }
        [Required(ErrorMessage = "Plese Fill this Filed")]
        public string officerSex { get; set; }
        [Required(ErrorMessage = "Plese Fill this Filed")]
        public string officerTelephone { get; set; }
        [Required(ErrorMessage = "Plese Fill this Filed")]
        public string officerJoindDate { get; set; }
        [Required(ErrorMessage = "Plese Fill this Filed")]
        public string officerDesignation { get; set; }
        [Required(ErrorMessage = "Plese Fill this Filed")]
        public string officerNIC { get; set; }

        public virtual Login Login { get; set; }

    }
}