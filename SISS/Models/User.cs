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
        [Required(ErrorMessage = "Plese Fill Employee Number")]
        public string UserEmployeeNumber { get; set; }
        [Required(ErrorMessage = "Plese Fill Name")]
        public string officerName { get; set; }
        [Required(ErrorMessage = "Plese Fill FullName")]
        public string officerFullName { get; set; }
        [Required(ErrorMessage = "Plese Fill Birthday")]
        public string officerBirthday { get; set; }
        [Required(ErrorMessage = "Plese Fill Police Station")]
        public string officerPoliceStation { get; set; }
        [Required(ErrorMessage = "Plese Fill MarrageStatus")]
        public string officerMarrageStatus { get; set; }
        [Required(ErrorMessage = "Plese Fill this Telephone")]
        public string officerTelephone { get; set; }
        [Required(ErrorMessage = "Plese Fill JoindDate ")]
        public string officerJoindDate { get; set; }
        [Required(ErrorMessage = "Plese Fill Designation")]
        public string officerDesignation { get; set; }
        [Required(ErrorMessage = "Plese Fill NIC Number")]
        public string officerNIC { get; set; }
        [Required(ErrorMessage = "Plese Fill Gender")]
        public string officerGender { get; set; }
        [NotMapped]
        public string UserErrorMessage { get; set; }
        [NotMapped]
        public string UserSuccessMessage { get; set; }


    }
    
}
public enum Gender
{
    Male,
    Female
}
public enum Designation
{
   DIG,
   OIC,
   Costapal
}
public enum MarridStatus
{
   Married,
   Unmarried
}
