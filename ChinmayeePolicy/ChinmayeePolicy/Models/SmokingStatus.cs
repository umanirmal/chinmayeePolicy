using System;
using System.Collections.Generic;

namespace ChinmayeePolicy
{
    public partial class SmokingStatus
    {
        public SmokingStatus()
        {
            Vitals = new HashSet<Vitals>();
        }

        public short SmokingStatusId { get; set; }
        public string Name { get; set; }

        public ICollection<Vitals> Vitals { get; set; }
    }
}
