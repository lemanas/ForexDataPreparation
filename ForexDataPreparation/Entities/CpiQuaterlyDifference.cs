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
        public int Id { get; set; }

        [Column(Order = 1)]
        public int Year { get; set; }

        [Column(Order = 2)]
        public int Quarter { get; set; }

        [Column(Order = 3)]
        public double Difference { get; set; }
    }
}
