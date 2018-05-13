using System;
using System.Collections.Generic;

namespace ChinmayeePolicy
{
    public partial class Vitals
    {
        public Vitals()
        {
            HealthInfo = new HashSet<HealthInfo>();
        }

        public short VitalsId { get; set; }
        public short? BloodPressureSystolic { get; set; }
        public short? BloodPressureDiastolic { get; set; }
        public short? Weight { get; set; }
        public short? Height { get; set; }
        public double? Temperature { get; set; }
        public DateTime? DateOfRecording { get; set; }
        public short? SmokingStatusId { get; set; }

        public SmokingStatus SmokingStatus { get; set; }
        public ICollection<HealthInfo> HealthInfo { get; set; }
    }
}
