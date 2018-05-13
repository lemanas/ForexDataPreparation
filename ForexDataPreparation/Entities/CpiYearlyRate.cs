using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForexDataPreparation.Entities
{
    [Table("CpiYearlyRates", Schema = "raw")]
    public class CpiYearlyRate
    {
        [Key]
        [Column(Order = 0)]
        public string Country { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Date { get; set; }

        [Column(Order = 2)]
        public double Rate { get; set; }
    }
}
