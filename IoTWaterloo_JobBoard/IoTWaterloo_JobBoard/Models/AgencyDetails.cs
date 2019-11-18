using System;
using System.Collections.Generic;

namespace IOTWaterloo_JobBoard.Models
{
    public partial class AgencyDetails
    {
        public AgencyDetails()
        {
            AgentDetails = new HashSet<AgentDetails>();
        }

        public int AgencyId { get; set; }
        public string AgencyName { get; set; }
        public string AgencyWebsite { get; set; }
        public int AgencyPhone { get; set; }
        public string AgencyEmail { get; set; }

        public virtual ICollection<AgentDetails> AgentDetails { get; set; }
    }
}
