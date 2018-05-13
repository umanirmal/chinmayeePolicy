using System;
using System.Collections.Generic;

namespace ChinmayeePolicy
{
    public partial class ServiceRestriction
    {
        public ServiceRestriction()
        {
            Plans = new HashSet<Plans>();
        }

        public short ServiceRestrictionId { get; set; }
        public short? RestrictionTypeId { get; set; }
        public string ProcedureQualifierCode { get; set; }
        public string ProcedureCodes { get; set; }
        public string ServiceFacilityType { get; set; }
        public string Service { get; set; }
        public string ServiceTypeCodesId { get; set; }
        public string InPlanNetwork { get; set; }
        public short? CoverageLevelId { get; set; }
        public short? DeliveryId { get; set; }

        public CoverageLevel CoverageLevel { get; set; }
        public Delivery Delivery { get; set; }
        public RestrictionType RestrictionType { get; set; }
        public ServiceTypeCodes ServiceTypeCodes { get; set; }
        public ICollection<Plans> Plans { get; set; }
    }
}
