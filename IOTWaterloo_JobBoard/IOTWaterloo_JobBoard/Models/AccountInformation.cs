using System;
using System.Collections.Generic;

namespace IOTWaterloo_JobBoard.Models
{
    public partial class AccountInformation
    {
        public AccountInformation()
        {
            AgentDetails = new HashSet<AgentDetails>();
            CandidateDetails = new HashSet<CandidateDetails>();
            CompanyDetails = new HashSet<CompanyDetails>();
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<AgentDetails> AgentDetails { get; set; }
        public virtual ICollection<CandidateDetails> CandidateDetails { get; set; }
        public virtual ICollection<CompanyDetails> CompanyDetails { get; set; }
    }
}
