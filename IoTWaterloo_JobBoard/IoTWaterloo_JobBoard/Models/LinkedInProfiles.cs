using System;
using System.Collections.Generic;

namespace IOTWaterloo_JobBoard.Models
{
    public partial class LinkedInProfiles
    {
        public LinkedInProfiles()
        {
            CandidateDetails = new HashSet<CandidateDetails>();
        }

        public int LinkedInId { get; set; }
        public string ProfilrUrl { get; set; }

        public virtual ICollection<CandidateDetails> CandidateDetails { get; set; }
    }
}
