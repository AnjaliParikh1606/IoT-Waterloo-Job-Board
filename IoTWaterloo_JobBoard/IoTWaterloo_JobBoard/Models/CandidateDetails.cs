using System;
using System.Collections.Generic;

namespace IoTWaterloo_JobBoard.Models
{
    public partial class CandidateDetails
    {
        public int CandidateId { get; set; }
        public string CandidateFirstName { get; set; }
        public string CandidateLastName { get; set; }
        public int ResumeId { get; set; }
        public int LinkedInId { get; set; }
        public string UserName { get; set; }

        public virtual LinkedInProfiles LinkedIn { get; set; }
        public virtual Resume Resume { get; set; }
        public virtual AcountInformation UserNameNavigation { get; set; }
    }
}
