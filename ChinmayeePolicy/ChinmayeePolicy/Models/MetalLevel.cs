using System;
using System.Collections.Generic;

namespace ChinmayeePolicy
{
    public partial class MetalLevel
    {
        public MetalLevel()
        {
            Plans = new HashSet<Plans>();
        }

        public short MetalLevelId { get; set; }
        public string Name { get; set; }

        public ICollection<Plans> Plans { get; set; }
    }
}
