using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ForexDataPreparation.Entities
{
    [Table("Trade", Schema = "raw")]
    public class Trade
    {
        [Key]
        [Column(Order = 0)]
        public string Country { get; set; }

        [Key]
        [Column(Order = 1)]
        public string Partner { get; set; }

        [Key]
        [Column(Order = 2)]
        public int Flow { get; set; }

        [Key]
        [Column(Order = 3)]
        public int Year { get; set; }

        [Key]
        [Column(Order = 4)]
        public double Value { get; set; }
    }
}
