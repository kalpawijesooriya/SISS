using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SISS.Models
{
    public class Temp
    {
        public class tempClass1
        {
            public decimal SuspectID { get; set; }
        }
        public class tempClass2
        {
            public decimal CrimeId { get; set; }
        }
        public class tempClass3
        {
            public decimal InvestigationId { get; set; }
        }

        public class tempClass4
        {
            public int CrimeId { get; set; }
            public string ComplaineDate { get; set; }
            public string CrimeName { get; set; }
            public string ComplaineTime { get; set; }
            public string ComplainantName { get; set; }
            public string ComplainAddress { get; set; }
            public string ComplainContactNo { get; set; }
            public string ComplainTitle { get; set; }
            public string Statment { get; set; }
            public string policeStation { get; set; }
            public string CrimeType { get; set; }
            public string CrimeLocation { get; set; }

            public int CrimeImageId { get; set; }
            public string imagePath { get; set; }
         
            public int SuspectID { get; set; }
            public string FullName { get; set; }
            public string Address { get; set; }
            public string NIC { get; set; }
            public string ContactNumber { get; set; }
            public string SuspectStatus { get; set; }

            public int CrimeOfficerId { get; set; }
            public string UserEmployeeNumber { get; set; }
            public int oder { get; set; }

            public int InvestigationId { get; set; }
            public string InvestigationStartDate { get; set; }
            public string CrimeLocationInvestigationDetails { get; set; }
            public string InvestigationStatus { get; set; }

            public string LocationimagePath { get; set; }


            public int ReportID { get; set; }
            public string SpecialistName { get; set; }
            public string ReportType { get; set; }
            public string Designation { get; set; }
            public string Discription { get; set; }

            public int WitnessId { get; set; }
            public String WitnessName { get; set; }
            public String WitnessNIC { get; set; }

            public String WitnessAddress { get; set; }
            public String WitnessTelephone { get; set; }
            public string WitnessDiscription { get; set; }

        }
        public class tempClass5
        {
            public int CrimeId { get; set; }
            public string ComplaineDate { get; set; }
            public string CrimeName { get; set; }
            public string policeStation { get; set; }
            public string CrimeLocation { get; set; }
            public string InvestigationStatus { get; set; }
        }
    }
}
