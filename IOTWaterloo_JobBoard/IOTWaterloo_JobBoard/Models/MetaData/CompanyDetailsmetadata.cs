using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IOTWaterloo_JobBoard.Models
{
    [ModelMetadataType(typeof(CompanyDetailsmetadata))]
    public partial class CompanyDetails : IValidatableObject
    {
        private JobBoardContext _conetext;
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            _conetext = (JobBoardContext)validationContext.GetService(typeof(JobBoardContext));
            //throw new NotImplementedException();

            if (string.IsNullOrEmpty(CompanyName))
                yield return new ValidationResult("Company Name must required");

            yield return ValidationResult.Success;
        }
    }

    public class CompanyDetailsmetadata
    {
        public CompanyDetailsmetadata()
        {
            JobDetails = new HashSet<JobDetails>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyPostalCode { get; set; }
        public string CompanyLandLinePhoneNumber { get; set; }
        public string CompanyLandLineExtensionNumber { get; set; }
        public string CompanyEmailId { get; set; }
        public DateTime? CompanyRegistrationDateTime { get; set; }
        public string CompanyContactPerson { get; set; }
        public int RoleId { get; set; }
        public string UserName { get; set; }

        public virtual Role Role { get; set; }
        public virtual AccountInformation UserNameNavigation { get; set; }
        public virtual ICollection<JobDetails> JobDetails { get; set; }
    }
}
