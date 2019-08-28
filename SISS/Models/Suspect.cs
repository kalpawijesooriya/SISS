using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SISS.Models
{
    public class Suspect
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SuspectID { get; set; }
        [Required(ErrorMessage = "Plese Fill FullName")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Plese Fill Name With Initials")]
        public string NameWithInitials { get; set; }
        [Required(ErrorMessage = "Plese Fill NickName")]
        public string NickName { get; set; }
        [Required(ErrorMessage = "Plese Fill Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Plese Fill CurrentCity")]
        public string CurrentCity { get; set; }
        [Required(ErrorMessage = "Plese Fill BirthDay")]
        public string BirthDay { get; set; }
        [Required(ErrorMessage = "Plese Fill NIC")]
        public string NIC { get; set; }
        [Required(ErrorMessage = "Plese Fill ContactNumber")]
        public string ContactNumber { get; set; }
        public string AddBy { get; set; }
        [NotMapped]
        public string SuspectErrorMessage { get; set; }
        [NotMapped]
        public string SuspectSuccessMessage { get; set; }

    }
}