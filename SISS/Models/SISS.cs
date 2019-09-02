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
        public DbSet<Suspect> Suspect { get; set; }
        public DbSet<Relation> Relation { get; set; }
        public DbSet<Crime> Crime { get; set; }
        public DbSet<CrimeOfficer> CrimeOfficer { get; set; }
        public DbSet<Investigation> Investigation { get; set; }
        public DbSet<Witnesses> Witnesses { get; set; }
        public DbSet<CrimeSuspects> CrimeSuspects { get; set; }
        public DbSet<InvestigationResults> InvestigationResults { get; set; }
        public DbSet<SpecialReports> SpecialReports { get; set; }
        public DbSet<CrimeImages> CrimeImages { get; set; }
        public DbSet<LocationImages> LocationImages { get; set; }

    }
}
