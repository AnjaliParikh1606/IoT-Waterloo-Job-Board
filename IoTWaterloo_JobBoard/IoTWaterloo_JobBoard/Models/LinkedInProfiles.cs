using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IOTWaterloo_JobBoard.Models
{
    public partial class LinkedInProfiles
    {
        public LinkedInProfiles()
        {
            CandidateDetails = new HashSet<CandidateDetails>();
        }

        [Key]
        public int LinkedInId { get; set; }
        public string ProfilrUrl { get; set; }

        public virtual ICollection<CandidateDetails> CandidateDetails { get; set; }
    }
}
