using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SISS.Models
{
    public class CrimeImages
    {
        [Key]
        public int CrimeImageId { get; set; }
        public string imagePath { get; set; }
        public int CrimeId { get; set; }
        [ForeignKey("CrimeId")]
        public Crime Crime { get; set; }
    }
}