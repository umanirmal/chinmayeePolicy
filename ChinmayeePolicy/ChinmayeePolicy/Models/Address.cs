using System;
using System.Collections.Generic;

namespace ChinmayeePolicy
{
    public partial class Address
    {
        public Address()
        {
            Payer = new HashSet<Payer>();
            Subscriber = new HashSet<Subscriber>();
        }

        public short AddressId { get; set; }
        public string AddressLines { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public string Country { get; set; }

        public ICollection<Payer> Payer { get; set; }
        public ICollection<Subscriber> Subscriber { get; set; }
    }
}
