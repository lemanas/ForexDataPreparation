using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForexDataPreparation.Entities
{
    [Table("CpiYearlyDifferences", Schema = "calc")]
    public class CpiYearlyDifference
    {
        [Key]
        [Column(Order = 0)]
        public int Id { get; set; }

        [Column(Order = 1)]
        public int Year { get; set; }

        [Column(Order = 2)]
        public double Difference { get; set; }
    }
}
