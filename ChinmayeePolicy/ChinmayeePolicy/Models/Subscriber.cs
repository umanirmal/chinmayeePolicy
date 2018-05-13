using System;
using System.Collections.Generic;

namespace ChinmayeePolicy
{
    public partial class Subscriber
    {
        public int SubscriberId { get; set; }
        public short? AddressId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }
        public string Gender { get; set; }
        public string Relationship { get; set; }
        public string GroupNumber { get; set; }
        public string MilitaryPersonnelInformation { get; set; }
        public string GroupName { get; set; }
        public string Ssn { get; set; }
        public string PayerResponsibility { get; set; }
        public string AuthorizePaymentToBillingProvider { get; set; }
        public string PatientSignatureSource { get; set; }
        public string ReleaseOfInformationCode { get; set; }

        public Address Address { get; set; }
    }
}
