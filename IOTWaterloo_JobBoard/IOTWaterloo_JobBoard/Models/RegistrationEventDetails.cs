using System;
using System.Collections.Generic;

namespace IOTWaterloo_JobBoard.Models
{
    public partial class RegistrationEventDetails
    {
        public int RegistrationId { get; set; }
        public int EventId { get; set; }

        public virtual EventDetails Event { get; set; }
    }
}
