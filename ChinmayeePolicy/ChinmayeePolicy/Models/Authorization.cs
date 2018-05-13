using System;
using System.Collections.Generic;

namespace ChinmayeePolicy
{
    public partial class Authorization
    {
        public int AuthorizationId { get; set; }
        public string Service { get; set; }
        public string ServiceTypeCodesId { get; set; }
        public string DiagnosticCodeQualifier { get; set; }
        public string DiagnosticCodes { get; set; }
        public short? AuthorizationRequiredId { get; set; }
        public short? DeliveryId { get; set; }
        public short? HealthInfoId { get; set; }

        public AuthorizationRequired AuthorizationRequired { get; set; }
        public Delivery Delivery { get; set; }
        public HealthInfo HealthInfo { get; set; }
        public ServiceTypeCodes ServiceTypeCodes { get; set; }
    }
}
