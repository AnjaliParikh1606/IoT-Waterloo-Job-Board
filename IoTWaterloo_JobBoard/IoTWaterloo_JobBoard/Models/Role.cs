using System;
using System.Collections.Generic;

namespace IOTWaterloo_JobBoard.Models
{
    public partial class Role
    {
        public Role()
        {
            AccountInformation = new HashSet<AccountInformation>();
            CompanyDetails = new HashSet<CompanyDetails>();
        }

        public int RoleId { get; set; }
        public string PermissionType { get; set; }

        public virtual ICollection<AccountInformation> AccountInformation { get; set; }
        public virtual ICollection<CompanyDetails> CompanyDetails { get; set; }
    }
}
