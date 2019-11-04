using System;
using System.Collections.Generic;

namespace IoTWaterloo_JobBoard.Models
{
    public partial class PaymentDetails
    {
        public PaymentDetails()
        {
            CompnaySubscription = new HashSet<CompnaySubscription>();
            RegistrationDetails = new HashSet<RegistrationDetails>();
        }

        public int PaymentId { get; set; }
        public string PaymentCardType { get; set; }
        public DateTime? PaymentDateTime { get; set; }

        public virtual ICollection<CompnaySubscription> CompnaySubscription { get; set; }
        public virtual ICollection<RegistrationDetails> RegistrationDetails { get; set; }
    }
}
