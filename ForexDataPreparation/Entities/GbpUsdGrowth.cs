namespace ForexDataPreparation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GbpUsdGrowth")]
    public partial class GbpUsdGrowth
    {
        [Key]
        [Column(Order = 0, TypeName = "datetime2")]
        public DateTime Date { get; set; }

        [Key]
        [Column(Order = 1)]
        public double CloseGrowth { get; set; }
    }
}
