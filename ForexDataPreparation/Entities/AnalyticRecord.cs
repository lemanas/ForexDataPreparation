using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ForexDataPreparation.Enums;

namespace ForexDataPreparation.Entities
{
    [Table("AnalyticRecords", Schema = "calc")]
    public class AnalyticRecord
    {
        [Key]
        [Column(Order = 0)]
        public int Year { get; set; }

        [Key]
        [Column(Order = 1)]
        public double CpiDifference { get; set; }

        [Key]
        [Column(Order = 2)]
        public double CpiTendency { get; set; }

        [Key]
        [Column(Order = 3)]
        public double InterestRateDifference { get; set; }

        [Key]
        [Column(Order = 4)]
        public double InterestRateTendency { get; set; }

        [Key]
        [Column(Order = 5)]
        public double TradeBalanceByUk { get; set; }

        [Key]
        [Column(Order = 6)]
        public double TradeBalanceByUs { get; set; }

        [Key]
        [Column(Order = 7)]
        public double DebtGrowthUk { get; set; }

        [Key]
        [Column(Order = 8)]
        public double DebtGrowthUs { get; set; }

        [Key]
        [Column(Order = 9)]
        public double ForexTendency { get; set; }

        [Key]
        [Column(Order = 10)]
        public Outcome Outcome { get; set; }
    }
}
