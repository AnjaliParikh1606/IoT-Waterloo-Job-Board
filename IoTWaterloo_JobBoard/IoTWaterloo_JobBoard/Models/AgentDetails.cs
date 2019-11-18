using System;
using System.Collections.Generic;

namespace IOTWaterloo_JobBoard.Models
{
    public partial class AgentDetails
    {
        public int AgentId { get; set; }
        public string AgentFirstName { get; set; }
        public string AgenntLastName { get; set; }
        public int AgentPhone { get; set; }
        public int? AgentExtensionNumber { get; set; }
        public int? AgencyId { get; set; }
        public string UserName { get; set; }

        public virtual AgencyDetails Agency { get; set; }
        public virtual AccountInformation UserNameNavigation { get; set; }
    }
}
