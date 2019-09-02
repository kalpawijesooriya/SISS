using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SISS.Models
{
    public class Crime
    {
        [Key]
        public int CrimeId { get; set; }
        [Required(ErrorMessage = "Plese Fill")]
        public string ComplaineDate { get; set; }
        [Required(ErrorMessage = "Plese Fill")]
        public string CrimeName { get; set; }
        [Required(ErrorMessage = "Plese Fill")]
        public string ComplaineTime { get; set; }
        [Required(ErrorMessage = "Plese Fill")]
        public string ComplainantName { get; set; }
        [Required(ErrorMessage = "Plese Fill")]
        public string ComplainAddress { get; set; }
        [Required(ErrorMessage = "Plese Fill")]
        public string ComplainContactNo { get; set; }
        [Required(ErrorMessage = "Plese Fill")]
        public string ComplainTitle { get; set; }
        [Required(ErrorMessage = "Plese Fill")]
        public string Statment { get; set; }       
        [Required(ErrorMessage = "Plese Fill")]
        public string policeStation { get; set; }
        public string CrimeType { get; set; }
     
        [Required(ErrorMessage = "Plese Fill")]
        public string CrimeLocation { get; set; }
  
      



    }
}