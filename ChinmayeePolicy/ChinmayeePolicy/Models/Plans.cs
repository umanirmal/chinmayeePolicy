using System;
using System.Collections.Generic;
using System.Collections;

namespace ChinmayeePolicy
{
    public partial class Plans
    {
        public int PlansId { get; set; }
        public string BenefitsSummaryUrl { get; set; }
        public string CustomerServicePhone { get; set; }
        public string Deductible { get; set; }
        public string DeductibleIndividual { get; set; }
        public string DeductibleFamily { get; set; }
        public string MaxOutOfPocket { get; set; }
        public string MaxOutOfPocketIndividual { get; set; }
        public string MaxOutOfFamily { get; set; }
        public short? MetalLevelId { get; set; }
        public string PlanName { get; set; }
        public BitArray PublicExchange { get; set; }
        public string PlanType { get; set; }
        public string Premiums { get; set; }
        public short? PremiumsAge { get; set; }
        public short? PremiumsAdults { get; set; }
        public short? PremiumsChildren { get; set; }
        public decimal? PremiumsCost { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string TradingPartnerId { get; set; }
        public string EmergencyRoom { get; set; }
        public string GenericDrugs { get; set; }
        public string InpatientFacility { get; set; }
        public string InpatientPhysician { get; set; }
        public string NonPreferredBrandDrugs { get; set; }
        public string PreferredBrandDrugs { get; set; }
        public string PrimaryCarePhysician { get; set; }
        public string Specialist { get; set; }
        public string SpecialtyDrugs { get; set; }
        public BitArray AllowsHsa { get; set; }
        public short? ServiceRestrictionId { get; set; }
        public short? MonetaryRestrictionsId { get; set; }

        public MetalLevel MetalLevel { get; set; }
        public MonetaryRestrictions MonetaryRestrictions { get; set; }
        public ServiceRestriction ServiceRestriction { get; set; }
    }
}
