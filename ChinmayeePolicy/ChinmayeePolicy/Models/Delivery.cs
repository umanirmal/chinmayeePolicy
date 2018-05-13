using System;
using System.Collections.Generic;

namespace ChinmayeePolicy
{
    public partial class Delivery
    {
        public Delivery()
        {
            Authorization = new HashSet<Authorization>();
            ServiceRestriction = new HashSet<ServiceRestriction>();
        }

        public short DeliveryId { get; set; }
        public string Units { get; set; }
        public string SampleSelectionModulus { get; set; }
        public short? TimePeriodQualifierId { get; set; }
        public short? PeriodCount { get; set; }
        public string DeliveryFrequencyCode { get; set; }
        public string DeliveryPatternTimeCode { get; set; }
        public short? Quantity { get; set; }
        public short? QuantityQualifierId { get; set; }

        public QuantityQualifier QuantityQualifier { get; set; }
        public TimePeriodQualifier TimePeriodQualifier { get; set; }
        public ICollection<Authorization> Authorization { get; set; }
        public ICollection<ServiceRestriction> ServiceRestriction { get; set; }
    }
}
