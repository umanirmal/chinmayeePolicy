using System;
using System.Collections.Generic;

namespace ChinmayeePolicy
{
    public partial class HealthInfo
    {
        public HealthInfo()
        {
            Authorization = new HashSet<Authorization>();
        }

        public short HealthInfoId { get; set; }
        public short? VitalsId { get; set; }
        public short? Age { get; set; }
        public string Gender { get; set; }
        public string HealthNotes { get; set; }

        public Vitals Vitals { get; set; }
        public ICollection<Authorization> Authorization { get; set; }
    }
}
