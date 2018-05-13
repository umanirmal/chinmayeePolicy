using System;
using System.Collections.Generic;

namespace ChinmayeePolicy
{
    public partial class RestrictionType
    {
        public RestrictionType()
        {
            ServiceRestriction = new HashSet<ServiceRestriction>();
        }

        public short RestrictionTypeId { get; set; }
        public string Name { get; set; }

        public ICollection<ServiceRestriction> ServiceRestriction { get; set; }
    }
}
