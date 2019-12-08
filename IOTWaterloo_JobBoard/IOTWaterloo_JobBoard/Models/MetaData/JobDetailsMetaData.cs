using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IOTWaterloo_JobBoard.Models
{
    [ModelMetadataType(typeof(JobDetailsMetaData))]
    public partial class JobDetails : IValidatableObject
    {

        /// <summary>
        /// Author:Anjali Parikh
        /// </summary>
        private JobBoardContext _context;
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            _context = (JobBoardContext)validationContext.GetService(typeof(JobBoardContext));

            if (string.IsNullOrEmpty(JobTitle))
                yield return new ValidationResult("Title must required");
            if (string.IsNullOrEmpty(Category))
                yield return new ValidationResult("Please select the category");
            if (string.IsNullOrEmpty(Jobtype))
                yield return new ValidationResult("Please select the jobtype");
            if (string.IsNullOrEmpty(JobDescription))
                yield return new ValidationResult("Please Add Job Description");
            if (!string.IsNullOrEmpty(JobPostDate.ToString()))
            {
                if (JobPostDate < DateTime.Now.Date)
                    yield return new ValidationResult("Job Posting Date must not be in past");
            }
            else yield return new ValidationResult("Please Select Job Posting Date and Time");

            if (!string.IsNullOrEmpty(JobExpiryDate.ToString()))
            {

                if (JobExpiryDate < DateTime.Now)
                    yield return new ValidationResult("Job Expiry Date must be in Future");
            }
            else yield return new ValidationResult("Please Select Job Expiry Date and Time");

            yield return ValidationResult.Success;
        }
    }
    public  class JobDetailsMetaData
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
        public string Jobtype { get; set; }
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
