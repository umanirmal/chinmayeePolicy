using System;
using System.Collections.Generic;

namespace ChinmayeePolicy
{
    public partial class Payer
    {
        public int PayerId { get; set; }
        public string MedicalPolicy { get; set; }
        public string Plans { get; set; }
        public string Network { get; set; }
        public string Contracts { get; set; }
        public string MedicalPolicyCategory { get; set; }
        public string Name { get; set; }
        public short? AddressId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public string Fax { get; set; }
        public string TaxId { get; set; }

        public Address Address { get; set; }
    }
}
