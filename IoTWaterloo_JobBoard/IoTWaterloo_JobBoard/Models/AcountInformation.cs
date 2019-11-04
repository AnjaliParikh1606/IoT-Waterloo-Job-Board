using System;
using System.Collections.Generic;

namespace IoTWaterloo_JobBoard.Models
{
    public partial class AcountInformation
    {
        public AcountInformation()
        {
            AgentDetails = new HashSet<AgentDetails>();
            CandidateDetails = new HashSet<CandidateDetails>();
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<AgentDetails> AgentDetails { get; set; }
        public virtual ICollection<CandidateDetails> CandidateDetails { get; set; }
    }
}
