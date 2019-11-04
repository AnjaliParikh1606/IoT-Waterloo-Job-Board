using System;
using System.Collections.Generic;

namespace IoTWaterloo_JobBoard.Models
{
    public partial class CompnaySubscription
    {
        public int SubscriptionId { get; set; }
        public DateTime? SubscriptionStartDate { get; set; }
        public DateTime? SubscriptionExprityDate { get; set; }
        public int PaymentId { get; set; }

        public virtual PaymentDetails Payment { get; set; }
    }
}
