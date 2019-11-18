using System;
using System.Collections.Generic;

namespace IOTWaterloo_JobBoard.Models
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
        public virtual AccountInformation UserNameNavigation { get; set; }
    }
}
