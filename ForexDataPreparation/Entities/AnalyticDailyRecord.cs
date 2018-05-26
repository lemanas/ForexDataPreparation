using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ForexDataPreparation.Enums;

namespace ForexDataPreparation.Entities
{
    [Table("AnalyticDailyRecords", Schema = "calc")]
    public class AnalyticDailyRecord
    {
        [Key]
        [Column(Order = 11)]
        public int Id { get; set; }

        [Column(Order = 0)]
        public DateTime Date { get; set; }

        [Column(Order = 1)]
        public double CpiDifference { get; set; }

        [Column(Order = 2)]
        public double CpiTendency { get; set; }

        [Column(Order = 3)]
        public double InterestRateDifference { get; set; }

        [Column(Order = 4)]
        public double InterestRateTendency { get; set; }

        [Column(Order = 5)]
        public double TradeBalanceByUk { get; set; }

        [Column(Order = 6)]
        public double TradeBalanceByUs { get; set; }

        [Column(Order = 7)]
        public double DebtGrowthUk { get; set; }

        [Column(Order = 8)]
        public double DebtGrowthUs { get; set; }

        [Column(Order = 9)]
        public double ForexTendency { get; set; }

        [Column(Order = 10)]
        public Outcome Outcome { get; set; }
    }
}
