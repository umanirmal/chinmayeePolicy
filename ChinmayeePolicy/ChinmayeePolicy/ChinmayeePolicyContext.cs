using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ChinmayeePolicy
{
    public partial class ChinmayeePolicyContext : DbContext
    {
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Authorization> Authorization { get; set; }
        public virtual DbSet<AuthorizationRequired> AuthorizationRequired { get; set; }
        public virtual DbSet<Benefit> Benefit { get; set; }
        public virtual DbSet<CostSharing> CostSharing { get; set; }
        public virtual DbSet<CoverageLevel> CoverageLevel { get; set; }
        public virtual DbSet<CoveragePolicy> CoveragePolicy { get; set; }
        public virtual DbSet<DeductibleOutOfPocket> DeductibleOutOfPocket { get; set; }
        public virtual DbSet<Delivery> Delivery { get; set; }
        public virtual DbSet<HealthInfo> HealthInfo { get; set; }
        public virtual DbSet<MetalLevel> MetalLevel { get; set; }
        public virtual DbSet<MonetaryAmountObject> MonetaryAmountObject { get; set; }
        public virtual DbSet<MonetaryRestrictions> MonetaryRestrictions { get; set; }
        public virtual DbSet<Payer> Payer { get; set; }
        public virtual DbSet<Plans> Plans { get; set; }
        public virtual DbSet<ProcedureIdQualifier> ProcedureIdQualifier { get; set; }
        public virtual DbSet<QuantityQualifier> QuantityQualifier { get; set; }
        public virtual DbSet<RestrictionType> RestrictionType { get; set; }
        public virtual DbSet<ServiceRestriction> ServiceRestriction { get; set; }
        public virtual DbSet<ServiceTypeCodes> ServiceTypeCodes { get; set; }
        public virtual DbSet<SmokingStatus> SmokingStatus { get; set; }
        public virtual DbSet<Subscriber> Subscriber { get; set; }
        public virtual DbSet<TimePeriodQualifier> TimePeriodQualifier { get; set; }
        public virtual DbSet<Vitals> Vitals { get; set; }

        public ChinmayeePolicyContext(DbContextOptions<ChinmayeePolicyContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql(@"Host=ec2-54-243-63-13.compute-1.amazonaws.com;Database=d46u65jgu6o7g0;Username=omdcyfxildwgvt;Password=6e5b3c77d3402669530985e7ed46aa6c5edbf441b588931b19b1769493207d3a;Use SSL Stream=True;Trust Server Certificate=True;SSL Mode=Require;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressId)
                    .HasColumnName("address_id")
                    .HasDefaultValueSql("nextval('address_id_seq'::regclass)");

                entity.Property(e => e.AddressLines).HasColumnName("address_lines");

                entity.Property(e => e.City).HasColumnName("city");

                entity.Property(e => e.Country).HasColumnName("country");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Zipcode).HasColumnName("zipcode");
            });

            modelBuilder.Entity<Authorization>(entity =>
            {
                entity.Property(e => e.AuthorizationId)
                    .HasColumnName("authorization_id")
                    .HasDefaultValueSql("nextval('authorization_id_seq'::regclass)");

                entity.Property(e => e.AuthorizationRequiredId).HasColumnName("authorization_required_id");

                entity.Property(e => e.DeliveryId).HasColumnName("delivery_id");

                entity.Property(e => e.DiagnosticCodeQualifier).HasColumnName("diagnostic_code_qualifier");

                entity.Property(e => e.DiagnosticCodes).HasColumnName("diagnostic_codes");

                entity.Property(e => e.HealthInfoId).HasColumnName("health_info_id");

                entity.Property(e => e.Service).HasColumnName("service");

                entity.Property(e => e.ServiceTypeCodesId).HasColumnName("service_type_codes_id");

                entity.HasOne(d => d.AuthorizationRequired)
                    .WithMany(p => p.Authorization)
                    .HasForeignKey(d => d.AuthorizationRequiredId)
                    .HasConstraintName("Authorization_authorization_required_id_fkey");

                entity.HasOne(d => d.Delivery)
                    .WithMany(p => p.Authorization)
                    .HasForeignKey(d => d.DeliveryId)
                    .HasConstraintName("Authorization_delivery_id_fkey");

                entity.HasOne(d => d.HealthInfo)
                    .WithMany(p => p.Authorization)
                    .HasForeignKey(d => d.HealthInfoId)
                    .HasConstraintName("Authorization_health_info_id_fkey");

                entity.HasOne(d => d.ServiceTypeCodes)
                    .WithMany(p => p.Authorization)
                    .HasForeignKey(d => d.ServiceTypeCodesId)
                    .HasConstraintName("Authorization_service_type_codes_id_fkey");
            });

            modelBuilder.Entity<AuthorizationRequired>(entity =>
            {
                entity.ToTable("Authorization_Required");

                entity.Property(e => e.AuthorizationRequiredId)
                    .HasColumnName("authorization_required_id")
                    .HasDefaultValueSql("nextval('authorization_required_id_seq'::regclass)");

                entity.Property(e => e.Meaning)
                    .IsRequired()
                    .HasColumnName("meaning");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value");
            });

            modelBuilder.Entity<Benefit>(entity =>
            {
                entity.Property(e => e.BenefitId)
                    .HasColumnName("benefit_id")
                    .HasDefaultValueSql("nextval('benefit_id_seq'::regclass)");

                entity.Property(e => e.BeginDate).HasColumnName("begin_date");

                entity.Property(e => e.CoverageLevelId).HasColumnName("coverage_level_id");

                entity.Property(e => e.Coverageactive)
                    .HasColumnName("coverageactive")
                    .HasColumnType("bit");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Drugs).HasColumnName("drugs");

                entity.Property(e => e.EndDate).HasColumnName("end_date");

                entity.Property(e => e.ServiceTypeCodesId).HasColumnName("service_type_codes_id");

                entity.Property(e => e.Services).HasColumnName("services");

                entity.HasOne(d => d.CoverageLevel)
                    .WithMany(p => p.Benefit)
                    .HasForeignKey(d => d.CoverageLevelId)
                    .HasConstraintName("Benefit_coverage_level_id_fkey");

                entity.HasOne(d => d.ServiceTypeCodes)
                    .WithMany(p => p.Benefit)
                    .HasForeignKey(d => d.ServiceTypeCodesId)
                    .HasConstraintName("Benefit_service_type_codes_id_fkey");
            });

            modelBuilder.Entity<CostSharing>(entity =>
            {
                entity.ToTable("Cost_Sharing");

                entity.Property(e => e.CostSharingId)
                    .HasColumnName("cost_sharing_id")
                    .HasDefaultValueSql("nextval('cost_sharing_id_seq'::regclass)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Field)
                    .IsRequired()
                    .HasColumnName("field");
            });

            modelBuilder.Entity<CoverageLevel>(entity =>
            {
                entity.ToTable("Coverage_Level");

                entity.Property(e => e.CoverageLevelId)
                    .HasColumnName("coverage_level_id")
                    .HasDefaultValueSql("nextval('coverage_level_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<CoveragePolicy>(entity =>
            {
                entity.ToTable("Coverage_Policy");

                entity.Property(e => e.CoveragePolicyId)
                    .HasColumnName("coverage_policy_id")
                    .HasDefaultValueSql("nextval('coverage_policy_id_seq'::regclass)");

                entity.Property(e => e.AuthorizationRestrictions).HasColumnName("authorization_restrictions");

                entity.Property(e => e.Benefits).HasColumnName("benefits");

                entity.Property(e => e.PolicyEffectiveDate).HasColumnName("policy_effective_date");

                entity.Property(e => e.PolicyNumber).HasColumnName("policy_number");

                entity.Property(e => e.ServiceRestrictions).HasColumnName("service_restrictions");

                entity.Property(e => e.TaxonomyCode).HasColumnName("taxonomy_code");
            });

            modelBuilder.Entity<DeductibleOutOfPocket>(entity =>
            {
                entity.HasKey(e => e.DeductibleId);

                entity.ToTable("Deductible_OutOfPocket");

                entity.Property(e => e.DeductibleId)
                    .HasColumnName("deductible_id")
                    .HasDefaultValueSql("nextval('deductible_outofpocket_id_seq'::regclass)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Field)
                    .IsRequired()
                    .HasColumnName("field");
            });

            modelBuilder.Entity<Delivery>(entity =>
            {
                entity.Property(e => e.DeliveryId)
                    .HasColumnName("delivery_id")
                    .HasDefaultValueSql("nextval('delivery_id_seq'::regclass)");

                entity.Property(e => e.DeliveryFrequencyCode).HasColumnName("delivery_frequency_code");

                entity.Property(e => e.DeliveryPatternTimeCode).HasColumnName("delivery_pattern_time_code");

                entity.Property(e => e.PeriodCount).HasColumnName("period_count");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.QuantityQualifierId).HasColumnName("quantity_qualifier_id");

                entity.Property(e => e.SampleSelectionModulus).HasColumnName("sample_selection_modulus");

                entity.Property(e => e.TimePeriodQualifierId).HasColumnName("time_period_qualifier_id");

                entity.Property(e => e.Units).HasColumnName("units");

                entity.HasOne(d => d.QuantityQualifier)
                    .WithMany(p => p.Delivery)
                    .HasForeignKey(d => d.QuantityQualifierId)
                    .HasConstraintName("Delivery_quantity_qualifier_id_fkey");

                entity.HasOne(d => d.TimePeriodQualifier)
                    .WithMany(p => p.Delivery)
                    .HasForeignKey(d => d.TimePeriodQualifierId)
                    .HasConstraintName("Delivery_time_period_qualifier_id_fkey");
            });

            modelBuilder.Entity<HealthInfo>(entity =>
            {
                entity.ToTable("Health_Info");

                entity.Property(e => e.HealthInfoId)
                    .HasColumnName("health_info_id")
                    .HasDefaultValueSql("nextval('health_info_id_seq'::regclass)");

                entity.Property(e => e.Age).HasColumnName("age");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.HealthNotes).HasColumnName("health_notes");

                entity.Property(e => e.VitalsId).HasColumnName("vitals_id");

                entity.HasOne(d => d.Vitals)
                    .WithMany(p => p.HealthInfo)
                    .HasForeignKey(d => d.VitalsId)
                    .HasConstraintName("Health_Info_vitals_id_fkey");
            });

            modelBuilder.Entity<MetalLevel>(entity =>
            {
                entity.ToTable("Metal_Level");

                entity.Property(e => e.MetalLevelId)
                    .HasColumnName("metal_level_id")
                    .HasDefaultValueSql("nextval('metal_level_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<MonetaryAmountObject>(entity =>
            {
                entity.HasKey(e => e.MonetaryamountId);

                entity.ToTable("MonetaryAmount_Object");

                entity.Property(e => e.MonetaryamountId)
                    .HasColumnName("monetaryamount_id")
                    .HasDefaultValueSql("nextval('monetaryamount_object_id_seq'::regclass)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Field)
                    .IsRequired()
                    .HasColumnName("field");
            });

            modelBuilder.Entity<MonetaryRestrictions>(entity =>
            {
                entity.ToTable("Monetary_Restrictions");

                entity.Property(e => e.MonetaryRestrictionsId)
                    .HasColumnName("monetary_restrictions_id")
                    .HasDefaultValueSql("nextval('monetary_restrictions_id_seq'::regclass)");

                entity.Property(e => e.Coinsurance).HasColumnName("coinsurance");

                entity.Property(e => e.Copay)
                    .HasColumnName("copay")
                    .HasColumnType("money");

                entity.Property(e => e.Delivery).HasColumnName("delivery");

                entity.Property(e => e.ServiceTypeCodesId).HasColumnName("service_type_codes_id");

                entity.HasOne(d => d.ServiceTypeCodes)
                    .WithMany(p => p.MonetaryRestrictions)
                    .HasForeignKey(d => d.ServiceTypeCodesId)
                    .HasConstraintName("Monetary_Restrictions_service_type_codes_id_fkey");
            });

            modelBuilder.Entity<Payer>(entity =>
            {
                entity.Property(e => e.PayerId)
                    .HasColumnName("payer_id")
                    .HasDefaultValueSql("nextval('payer_id_seq'::regclass)");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.Contracts).HasColumnName("contracts");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.Fax).HasColumnName("fax");

                entity.Property(e => e.MedicalPolicy).HasColumnName("medical_policy");

                entity.Property(e => e.MedicalPolicyCategory).HasColumnName("medical_policy_category");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Network).HasColumnName("network");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Plans).HasColumnName("plans");

                entity.Property(e => e.TaxId).HasColumnName("tax_id");

                entity.Property(e => e.Url).HasColumnName("url");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Payer)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("Payer_address_id_fkey");
            });

            modelBuilder.Entity<Plans>(entity =>
            {
                entity.Property(e => e.PlansId)
                    .HasColumnName("plans_id")
                    .HasDefaultValueSql("nextval('plans_id_seq'::regclass)");

                entity.Property(e => e.AllowsHsa)
                    .HasColumnName("allows_hsa")
                    .HasColumnType("bit");

                entity.Property(e => e.BenefitsSummaryUrl).HasColumnName("benefits_summary_url");

                entity.Property(e => e.County).HasColumnName("county");

                entity.Property(e => e.CustomerServicePhone).HasColumnName("customer_service_phone");

                entity.Property(e => e.Deductible).HasColumnName("deductible");

                entity.Property(e => e.DeductibleFamily).HasColumnName("deductible_family");

                entity.Property(e => e.DeductibleIndividual).HasColumnName("deductible_individual");

                entity.Property(e => e.EmergencyRoom).HasColumnName("emergency_room");

                entity.Property(e => e.GenericDrugs).HasColumnName("generic_drugs");

                entity.Property(e => e.InpatientFacility).HasColumnName("inpatient_facility");

                entity.Property(e => e.InpatientPhysician).HasColumnName("inpatient_physician");

                entity.Property(e => e.MaxOutOfFamily).HasColumnName("max_out_of_family");

                entity.Property(e => e.MaxOutOfPocket).HasColumnName("max_out_of_pocket");

                entity.Property(e => e.MaxOutOfPocketIndividual).HasColumnName("max_out_of_pocket_individual");

                entity.Property(e => e.MetalLevelId).HasColumnName("metal_level_id");

                entity.Property(e => e.MonetaryRestrictionsId).HasColumnName("monetary_restrictions_id");

                entity.Property(e => e.NonPreferredBrandDrugs).HasColumnName("non_preferred_brand_drugs");

                entity.Property(e => e.PlanName).HasColumnName("plan_name");

                entity.Property(e => e.PlanType).HasColumnName("plan_type");

                entity.Property(e => e.PreferredBrandDrugs).HasColumnName("preferred_brand_drugs");

                entity.Property(e => e.Premiums).HasColumnName("premiums");

                entity.Property(e => e.PremiumsAdults).HasColumnName("premiums_adults");

                entity.Property(e => e.PremiumsAge).HasColumnName("premiums_age");

                entity.Property(e => e.PremiumsChildren).HasColumnName("premiums_children");

                entity.Property(e => e.PremiumsCost)
                    .HasColumnName("premiums_cost")
                    .HasColumnType("money");

                entity.Property(e => e.PrimaryCarePhysician).HasColumnName("primary_care_physician");

                entity.Property(e => e.PublicExchange)
                    .HasColumnName("public_exchange")
                    .HasColumnType("bit");

                entity.Property(e => e.ServiceRestrictionId).HasColumnName("service_restriction_id");

                entity.Property(e => e.Specialist).HasColumnName("specialist");

                entity.Property(e => e.SpecialtyDrugs).HasColumnName("specialty_drugs");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.TradingPartnerId).HasColumnName("trading_partner_id");

                entity.HasOne(d => d.MetalLevel)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.MetalLevelId)
                    .HasConstraintName("Plans_metal_level_id_fkey");

                entity.HasOne(d => d.MonetaryRestrictions)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.MonetaryRestrictionsId)
                    .HasConstraintName("Plans_monetary_restrictions_id_fkey");

                entity.HasOne(d => d.ServiceRestriction)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.ServiceRestrictionId)
                    .HasConstraintName("Plans_service_restriction_id_fkey");
            });

            modelBuilder.Entity<ProcedureIdQualifier>(entity =>
            {
                entity.ToTable("Procedure_id_qualifier");

                entity.Property(e => e.ProcedureIdQualifierId)
                    .HasColumnName("procedure_id_qualifier_id")
                    .HasDefaultValueSql("nextval('procedure_id_qualifier_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<QuantityQualifier>(entity =>
            {
                entity.ToTable("Quantity_Qualifier");

                entity.Property(e => e.QuantityQualifierId)
                    .HasColumnName("quantity_qualifier_id")
                    .HasDefaultValueSql("nextval('quantity_qualifier_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<RestrictionType>(entity =>
            {
                entity.ToTable("Restriction_Type");

                entity.Property(e => e.RestrictionTypeId)
                    .HasColumnName("restriction_type_id")
                    .HasDefaultValueSql("nextval('restriction_type_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<ServiceRestriction>(entity =>
            {
                entity.ToTable("Service_Restriction");

                entity.Property(e => e.ServiceRestrictionId)
                    .HasColumnName("service_restriction_id")
                    .HasDefaultValueSql("nextval('service_restriction_id_seq'::regclass)");

                entity.Property(e => e.CoverageLevelId).HasColumnName("coverage_level_id");

                entity.Property(e => e.DeliveryId).HasColumnName("delivery_id");

                entity.Property(e => e.InPlanNetwork).HasColumnName("in_plan_network");

                entity.Property(e => e.ProcedureCodes).HasColumnName("procedure_codes");

                entity.Property(e => e.ProcedureQualifierCode).HasColumnName("procedure_qualifier_code");

                entity.Property(e => e.RestrictionTypeId).HasColumnName("restriction_type_id");

                entity.Property(e => e.Service).HasColumnName("service");

                entity.Property(e => e.ServiceFacilityType).HasColumnName("service_facility_type");

                entity.Property(e => e.ServiceTypeCodesId).HasColumnName("service_type_codes_id");

                entity.HasOne(d => d.CoverageLevel)
                    .WithMany(p => p.ServiceRestriction)
                    .HasForeignKey(d => d.CoverageLevelId)
                    .HasConstraintName("Service_Restriction_coverage_level_id_fkey");

                entity.HasOne(d => d.Delivery)
                    .WithMany(p => p.ServiceRestriction)
                    .HasForeignKey(d => d.DeliveryId)
                    .HasConstraintName("Service_Restriction_delivery_id_fkey");

                entity.HasOne(d => d.RestrictionType)
                    .WithMany(p => p.ServiceRestriction)
                    .HasForeignKey(d => d.RestrictionTypeId)
                    .HasConstraintName("Service_Restriction_restriction_type_id_fkey");

                entity.HasOne(d => d.ServiceTypeCodes)
                    .WithMany(p => p.ServiceRestriction)
                    .HasForeignKey(d => d.ServiceTypeCodesId)
                    .HasConstraintName("Service_Restriction_service_type_codes_id_fkey");
            });

            modelBuilder.Entity<ServiceTypeCodes>(entity =>
            {
                entity.HasKey(e => e.CodeX12Spec);

                entity.ToTable("Service_type_Codes");

                entity.Property(e => e.CodeX12Spec)
                    .HasColumnName("code_x12_spec")
                    .ValueGeneratedNever();

                entity.Property(e => e.ServiceType)
                    .IsRequired()
                    .HasColumnName("service_type");
            });

            modelBuilder.Entity<SmokingStatus>(entity =>
            {
                entity.ToTable("Smoking_Status");

                entity.Property(e => e.SmokingStatusId)
                    .HasColumnName("smoking_status_id")
                    .HasDefaultValueSql("nextval('smoking_status_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Subscriber>(entity =>
            {
                entity.Property(e => e.SubscriberId)
                    .HasColumnName("subscriber_id")
                    .HasDefaultValueSql("nextval('subscriber_id_seq'::regclass)");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.AuthorizePaymentToBillingProvider).HasColumnName("authorize_payment_to_billing_provider");

                entity.Property(e => e.Birthdate).HasColumnName("birthdate");

                entity.Property(e => e.FirstName).HasColumnName("first_name");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.GroupName).HasColumnName("group_name");

                entity.Property(e => e.GroupNumber).HasColumnName("group_number");

                entity.Property(e => e.LastName).HasColumnName("last_name");

                entity.Property(e => e.MiddleName).HasColumnName("middle_name");

                entity.Property(e => e.MilitaryPersonnelInformation).HasColumnName("military_personnel_information");

                entity.Property(e => e.PatientSignatureSource).HasColumnName("patient_signature_source");

                entity.Property(e => e.PayerResponsibility).HasColumnName("payer_responsibility");

                entity.Property(e => e.Relationship).HasColumnName("relationship");

                entity.Property(e => e.ReleaseOfInformationCode).HasColumnName("release_of_information_code");

                entity.Property(e => e.Ssn).HasColumnName("ssn");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Subscriber)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("Subscriber_address_id_fkey");
            });

            modelBuilder.Entity<TimePeriodQualifier>(entity =>
            {
                entity.ToTable("Time_Period_Qualifier");

                entity.Property(e => e.TimePeriodQualifierId)
                    .HasColumnName("time_period_qualifier_id")
                    .HasDefaultValueSql("nextval('time_period_qualifier_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Vitals>(entity =>
            {
                entity.Property(e => e.VitalsId)
                    .HasColumnName("vitals_id")
                    .HasDefaultValueSql("nextval('vitals_id_seq'::regclass)");

                entity.Property(e => e.BloodPressureDiastolic).HasColumnName("blood_pressure_diastolic");

                entity.Property(e => e.BloodPressureSystolic).HasColumnName("blood_pressure_systolic");

                entity.Property(e => e.DateOfRecording).HasColumnName("date_of_recording");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.SmokingStatusId).HasColumnName("smoking_status_id");

                entity.Property(e => e.Temperature).HasColumnName("temperature");

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.HasOne(d => d.SmokingStatus)
                    .WithMany(p => p.Vitals)
                    .HasForeignKey(d => d.SmokingStatusId)
                    .HasConstraintName("Vitals_smoking_status_id_fkey");
            });

            modelBuilder.HasSequence("address_id_seq");

            modelBuilder.HasSequence("authorization_id_seq");

            modelBuilder.HasSequence("authorization_required_id_seq");

            modelBuilder.HasSequence("benefit_id_seq");

            modelBuilder.HasSequence("cost_sharing_id_seq");

            modelBuilder.HasSequence("coverage_level_id_seq");

            modelBuilder.HasSequence("coverage_policy_id_seq");

            modelBuilder.HasSequence("deductible_outofpocket_id_seq");

            modelBuilder.HasSequence("delivery_id_seq");

            modelBuilder.HasSequence("health_info_id_seq");

            modelBuilder.HasSequence("metal_level_id_seq");

            modelBuilder.HasSequence("monetary_restrictions_id_seq");

            modelBuilder.HasSequence("monetaryamount_object_id_seq");

            modelBuilder.HasSequence("payer_id_seq");

            modelBuilder.HasSequence("plans_id_seq");

            modelBuilder.HasSequence("procedure_id_qualifier_id_seq");

            modelBuilder.HasSequence("quantity_qualifier_id_seq");

            modelBuilder.HasSequence("restriction_type_id_seq");

            modelBuilder.HasSequence("service_restriction_id_seq");

            modelBuilder.HasSequence("smoking_status_id_seq");

            modelBuilder.HasSequence("subscriber_id_seq");

            modelBuilder.HasSequence("time_period_qualifier_id_seq");

            modelBuilder.HasSequence("vitals_id_seq");
        }
    }
}
