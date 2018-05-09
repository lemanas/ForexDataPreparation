using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ForexDataPreparation.Interfaces;

namespace ForexDataPreparation.Entities
{
    [Table("CpiQuaterlyDifferences", Schema = "calc")]
    public class CpiQuaterlyDifference : IQuarterly
    {
        [Key]
        [Column(Order = 0)]
        public int Year { get; set; }

        [Key]
        [Column(Order = 1)]
        public int Quarter { get; set; }

        [Key]
        [Column(Order = 2)]
        public double Difference { get; set; }
    }
}
