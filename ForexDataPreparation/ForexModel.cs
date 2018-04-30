namespace ForexDataPreparation
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ForexModel : DbContext
    {
        public ForexModel()
            : base("name=ForexModel")
        {
        }

        public virtual DbSet<GbpUsd> GbpUsd { get; set; }
        public virtual DbSet<GbpUsdGrowth> GbpUsdGrowth { get; set; }
        public virtual DbSet<UsdGbp> UsdGbp { get; set; }
        public virtual DbSet<UsdGbpGrowth> UsdGbpGrowth { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
