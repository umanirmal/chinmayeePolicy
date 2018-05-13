using System;
using System.Collections.Generic;

namespace ChinmayeePolicy
{
    public partial class TimePeriodQualifier
    {
        public TimePeriodQualifier()
        {
            Delivery = new HashSet<Delivery>();
        }

        public short TimePeriodQualifierId { get; set; }
        public string Name { get; set; }

        public ICollection<Delivery> Delivery { get; set; }
    }
}
