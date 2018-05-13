using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForexDataPreparation.Entities
{
    [Table("Debts", Schema = "raw")]
    public class Debt
    {
        [Key]
        [Column(Order = 0)]
        public string Country { get; set; }

        [Key]
        [Column(Order = 1)]
        public int Year { get; set; }

        [Column(Order = 2)]
        public double PercentageDebt { get; set; }
    }
}
