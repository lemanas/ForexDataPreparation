using ForexDataPreparation.Entities;
using System.Data.Entity;

namespace ForexDataPreparation
{
    public class ForexModel : DbContext
    {
        public ForexModel()
            : base("name=ForexModel")
        {
        }

        public virtual DbSet<GbpUsd> GbpUsd { get; set; }
        public virtual DbSet<GbpUsdGrowth> GbpUsdGrowth { get; set; }
        public virtual DbSet<UsdGbp> UsdGbp { get; set; }
        public virtual DbSet<UsdGbpGrowth> UsdGbpGrowth { get; set; }
        public virtual DbSet<GbpUsdGrowthQuaterly> GbpUsdGrowthQuaterlies { get; set; }
        public virtual DbSet<UsdGbpGrowthQuaterly> UsdGbpGrowthQuaterlies { get; set; }
        public virtual DbSet<UkInterestRate> UkInterestRates { get; set; }
        public virtual DbSet<UsMonthlyInterestRate> UsMonthlyInterestRates { get; set; }
        public virtual DbSet<CpiRate> CpiRates { get; set; }
        public virtual DbSet<CpiQuaterlyRate> CpiQuaterlyRates { get; set; }
        public virtual DbSet<CpiYearlyRate> CpiYearlyRates { get; set; }
        public virtual DbSet<Trade> Trades { get; set; }
        public virtual DbSet<Debt> Debts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
