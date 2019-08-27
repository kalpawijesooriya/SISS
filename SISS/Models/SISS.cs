using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SISS.Models;

namespace SISS 
{
    public class SISS_Context : DbContext
    {
        public SISS_Context() : base("name=SISS_context")
        {

        }
        public DbSet<Login> Login { get; set; }
        public DbSet<User> User { get; set; }
    }
}