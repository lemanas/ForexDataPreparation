using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForexDataPreparation.Entities
{
    [Table("UkInterestRates", Schema = "raw")]
    public class UkInterestRate
    {
        [Key]
        [Column(Order = 0)]
        public string Date { get; set; }

        [Column(Order = 1)]
        public double Rate { get; set; }
    }
}
