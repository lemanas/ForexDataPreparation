using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForexDataPreparation.Entities
{
    [Table("DebtGrowths", Schema = "calc")]
    public class DebtGrowth
    {
        [Key]
        [Column(Order = 0)]
        public string Country { get; set; }

        [Key]
        [Column(Order = 1)]
        public int Year { get; set; }

        [Key]
        [Column(Order = 2)]
        public double Growth { get; set; }
    }
}
