using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOTWaterloo_JobBoard.ViewModel
{
    public class JobViewModel
    {

        public string JobTitle { get; set; }

        public string Location { get; set; }

        public string JobPostDate { get; set; }

        public string Jobtype { get; set; }

        public DateTime? JobDate
        {
            get
            {
                if (JobPostDate == "lastWeek") return DateTime.UtcNow.AddDays(-7);
                if (JobPostDate == "lastMonth") return DateTime.UtcNow.AddDays(-30);
                if (JobPostDate == "recent") return DateTime.UtcNow.AddDays(-2);
                return null;
            }
        }
    }
}
