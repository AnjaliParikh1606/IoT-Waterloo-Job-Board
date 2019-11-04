using System;
using System.Collections.Generic;

namespace IoTWaterloo_JobBoard.Models
{
    public partial class Role
    {
        public Role()
        {
            AcountInformation = new HashSet<AcountInformation>();
            CompanyDetails = new HashSet<CompanyDetails>();
        }

        public int RoleId { get; set; }
        public string PermissionType { get; set; }

        public virtual ICollection<AcountInformation> AcountInformation { get; set; }
        public virtual ICollection<CompanyDetails> CompanyDetails { get; set; }
    }
}
