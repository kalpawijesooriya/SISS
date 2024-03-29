﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SISS.Models
{
    public class Login
    {
        [Key]
       
        public int Id { get; set; }
        [Required(ErrorMessage = "Plese Enter Your User PassWord")]
        public string password { get; set; }
        [Required(ErrorMessage = "Plese Enter Your User Name")]
        public string userName { get; set; }
        [NotMapped]
        public string LoginErrorMessage { get; set; }
        public string Role { get; set; }
        public string UserEmployeeNumber { get; set; }
        [ForeignKey("UserEmployeeNumber")]
        public User User { get; set; }


    }
}