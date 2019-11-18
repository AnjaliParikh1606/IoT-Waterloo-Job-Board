using System;
using System.Collections.Generic;

namespace IOTWaterloo_JobBoard.Models
{
    public partial class EventDetails
    {
        public EventDetails()
        {
            RegistrationEventDetails = new HashSet<RegistrationEventDetails>();
        }

        public int EventId { get; set; }
        public string EventName { get; set; }
        public string EventType { get; set; }
        public string EventLocation { get; set; }
        public DateTime EventSratDateTime { get; set; }
        public DateTime EventEndDateTime { get; set; }
        public string EventDescription { get; set; }
        public string SubscriberEmailId { get; set; }

        public virtual WebsiteSubscriber SubscriberEmail { get; set; }
        public virtual ICollection<RegistrationEventDetails> RegistrationEventDetails { get; set; }
    }
}
