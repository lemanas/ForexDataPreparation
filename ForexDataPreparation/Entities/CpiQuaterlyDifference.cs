using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForexDataPreparation.Entities
{
    [Table("CpiQuaterlyDifferences", Schema = "calc")]
    public class CpiQuaterlyDifference
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
