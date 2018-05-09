using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForexDataPreparation.Entities
{
    [Table("InterestRateQuaterlyDifferences", Schema = "calc")]
    public class InterestRateQuaterlyDifference
    {
        [Key]
        [Column(Order = 0)]
        public int Year { get; set; }

        [Key]
        [Column(Order = 1)]
        public int Quater { get; set; }

        [Key]
        [Column(Order = 2)]
        public double Difference { get; set; }
    }
}
