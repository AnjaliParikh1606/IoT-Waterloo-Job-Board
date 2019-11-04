using System;
using System.Collections.Generic;

namespace IoTWaterloo_JobBoard.Models
{
    public partial class CompanyDetails
    {
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
    }
}
