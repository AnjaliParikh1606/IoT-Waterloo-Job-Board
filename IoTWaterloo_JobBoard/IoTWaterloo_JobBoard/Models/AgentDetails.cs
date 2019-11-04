using System;
using System.Collections.Generic;

namespace IoTWaterloo_JobBoard.Models
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
        public virtual AcountInformation UserNameNavigation { get; set; }
    }
}
