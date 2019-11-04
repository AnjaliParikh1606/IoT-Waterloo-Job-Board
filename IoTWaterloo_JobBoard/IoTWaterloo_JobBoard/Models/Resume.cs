using System;
using System.Collections.Generic;

namespace IoTWaterloo_JobBoard.Models
{
    public partial class Resume
    {
        public Resume()
        {
            CandidateDetails = new HashSet<CandidateDetails>();
        }

        public int ResumeId { get; set; }
        public string FilePath { get; set; }

        public virtual ICollection<CandidateDetails> CandidateDetails { get; set; }
    }
}
