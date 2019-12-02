using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace IOTWaterloo_JobBoard.Models
{
    public partial class JobDetails
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        //[BindProperty]
        public string Jobtype { get; set; }
        //public string[] Jobtypes = new[] { "PartTime", "FullTime" };
        public decimal? MaxSalary { get; set; }
        public decimal? MinSalary { get; set; }
        public string JobDescription { get; set; }
        public decimal? PayPeriod { get; set; }
        public int? NumberOfPosition { get; set; }
        public DateTime? JobPostDate { get; set; }
        public DateTime? JobExpiryDate { get; set; }
        public int CompnayId { get; set; }

        public virtual CompanyDetails Compnay { get; set; }
    }
}
