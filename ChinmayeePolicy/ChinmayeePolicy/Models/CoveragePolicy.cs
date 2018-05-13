using System;
using System.Collections.Generic;

namespace ChinmayeePolicy
{
    public partial class CoveragePolicy
    {
        public int CoveragePolicyId { get; set; }
        public string Benefits { get; set; }
        public string ServiceRestrictions { get; set; }
        public string PolicyNumber { get; set; }
        public DateTime? PolicyEffectiveDate { get; set; }
        public string TaxonomyCode { get; set; }
        public string AuthorizationRestrictions { get; set; }
    }
}
