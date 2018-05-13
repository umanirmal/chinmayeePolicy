using System;
using System.Collections.Generic;

namespace ChinmayeePolicy
{
    public partial class AuthorizationRequired
    {
        public AuthorizationRequired()
        {
            Authorization = new HashSet<Authorization>();
        }

        public short AuthorizationRequiredId { get; set; }
        public string Value { get; set; }
        public string Meaning { get; set; }

        public ICollection<Authorization> Authorization { get; set; }
    }
}
