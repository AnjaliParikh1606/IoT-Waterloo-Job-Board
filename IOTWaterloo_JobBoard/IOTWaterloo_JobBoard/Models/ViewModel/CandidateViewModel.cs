using Microsoft.AspNetCore.Http;
using IOTWaterloo_JobBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOTWaterloo_JobBoard.ViewModel
{
    public class CandidateViewModel
    {
        public JobDetails jobDetails { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string URL { get; set; }
        public IFormFile Document { get; set; }
    }
}
