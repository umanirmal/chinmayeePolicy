using System;
using System.Collections.Generic;

namespace ChinmayeePolicy
{
    public partial class QuantityQualifier
    {
        public QuantityQualifier()
        {
            Delivery = new HashSet<Delivery>();
        }

        public short QuantityQualifierId { get; set; }
        public string Name { get; set; }

        public ICollection<Delivery> Delivery { get; set; }
    }
}
