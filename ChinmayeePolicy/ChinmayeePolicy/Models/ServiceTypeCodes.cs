using System;
using System.Collections.Generic;

namespace ChinmayeePolicy
{
    public partial class ServiceTypeCodes
    {
        public ServiceTypeCodes()
        {
            Authorization = new HashSet<Authorization>();
            Benefit = new HashSet<Benefit>();
            MonetaryRestrictions = new HashSet<MonetaryRestrictions>();
            ServiceRestriction = new HashSet<ServiceRestriction>();
        }

        public string CodeX12Spec { get; set; }
        public string ServiceType { get; set; }

        public ICollection<Authorization> Authorization { get; set; }
        public ICollection<Benefit> Benefit { get; set; }
        public ICollection<MonetaryRestrictions> MonetaryRestrictions { get; set; }
        public ICollection<ServiceRestriction> ServiceRestriction { get; set; }
    }
}
