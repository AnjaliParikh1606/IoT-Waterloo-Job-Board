using System;
using System.Collections.Generic;

namespace IoTWaterloo_JobBoard.Models
{
    public partial class RegistrationDetails
    {
        public int RegistrationId { get; set; }
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public DateTime RegistrationDateTime { get; set; }
        public int PaymentId { get; set; }

        public virtual PaymentDetails Payment { get; set; }
    }
}
