using System;
using System.Collections.Generic;

namespace ChinmayeePolicy
{
    public partial class MonetaryRestrictions
    {
        public MonetaryRestrictions()
        {
            Plans = new HashSet<Plans>();
        }

        public short MonetaryRestrictionsId { get; set; }
        public decimal? Copay { get; set; }
        public short? Coinsurance { get; set; }
        public string ServiceTypeCodesId { get; set; }
        public string Delivery { get; set; }

        public ServiceTypeCodes ServiceTypeCodes { get; set; }
        public ICollection<Plans> Plans { get; set; }
    }
}
