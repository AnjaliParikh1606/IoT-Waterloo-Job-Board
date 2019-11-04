using System;
using System.Collections.Generic;

namespace IoTWaterloo_JobBoard.Models
{
    public partial class WebsiteSubscriber
    {
        public WebsiteSubscriber()
        {
            EventDetails = new HashSet<EventDetails>();
            NewsLetter = new HashSet<NewsLetter>();
        }

        public string SubscriberEmailId { get; set; }

        public virtual ICollection<EventDetails> EventDetails { get; set; }
        public virtual ICollection<NewsLetter> NewsLetter { get; set; }
    }
}
