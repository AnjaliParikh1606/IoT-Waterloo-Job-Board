using System;
using System.Collections.Generic;

namespace IOTWaterloo_JobBoard.Models
{
    public partial class NewsLetter
    {
        public string NewsletterId { get; set; }
        public string Discription { get; set; }
        public string SubscriptionEmailId { get; set; }

        public virtual WebsiteSubscriber SubscriptionEmail { get; set; }
    }
}
