using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForexDataPreparation.Entities
{
    [Table("UsMonthlyInterestRates", Schema = "raw")]
    public class UsMonthlyInterestRate
    {
        [Key]
        [Column(Order = 0)]
        public DateTime Date { get; set; }

        [Key]
        [Column(Order = 1)]
        public double Rate { get; set; }
    }
}
