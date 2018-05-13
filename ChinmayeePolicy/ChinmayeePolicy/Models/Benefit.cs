using System;
using System.Collections.Generic;
using System.Collections;

namespace ChinmayeePolicy
{
    public partial class Benefit
    {
        public int BenefitId { get; set; }
        public BitArray Coverageactive { get; set; }
        public string Services { get; set; }
        public string ServiceTypeCodesId { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public short? CoverageLevelId { get; set; }
        public string Drugs { get; set; }

        public CoverageLevel CoverageLevel { get; set; }
        public ServiceTypeCodes ServiceTypeCodes { get; set; }
    }
}
