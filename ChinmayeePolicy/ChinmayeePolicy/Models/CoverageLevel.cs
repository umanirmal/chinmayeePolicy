using System;
using System.Collections.Generic;

namespace ChinmayeePolicy
{
    public partial class CoverageLevel
    {
        public CoverageLevel()
        {
            Benefit = new HashSet<Benefit>();
            ServiceRestriction = new HashSet<ServiceRestriction>();
        }

        public short CoverageLevelId { get; set; }
        public string Name { get; set; }

        public ICollection<Benefit> Benefit { get; set; }
        public ICollection<ServiceRestriction> ServiceRestriction { get; set; }
    }
}
