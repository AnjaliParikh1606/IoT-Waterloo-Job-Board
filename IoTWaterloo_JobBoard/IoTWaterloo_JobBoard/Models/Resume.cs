using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IOTWaterloo_JobBoard.Models
{
    public partial class Resume
    {
        public Resume()
        {
            CandidateDetails = new HashSet<CandidateDetails>();
        }

        [Key]
        public int ResumeId { get; set; }
        public string FilePath { get; set; }

        public virtual ICollection<CandidateDetails> CandidateDetails { get; set; }
    }
}
