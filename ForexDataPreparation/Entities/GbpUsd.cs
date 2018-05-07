using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ForexDataPreparation.Interfaces;

namespace ForexDataPreparation.Entities
{
    [Table("GbpUsd", Schema = "raw")]
    public class GbpUsd : IRawData
    {
        [Key]
        [Column(Order = 0, TypeName = "datetime2")]
        public DateTime Date { get; set; }

        [Key]
        [Column(Order = 1)]
        public double Open { get; set; }

        [Key]
        [Column(Order = 2)]
        public double High { get; set; }

        [Key]
        [Column(Order = 3)]
        public double Low { get; set; }

        [Key]
        [Column(Order = 4)]
        public double Close { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Volume { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OpenInt { get; set; }
    }
}
