using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ForexDataPreparation.Interfaces;

namespace ForexDataPreparation.Entities
{
    [Table("UsdGbpGrowth", Schema = "calc")]
    public class UsdGbpGrowth : IGrowth
    {
        [Key]
        [Column(Order = 0, TypeName = "datetime2")]
        public DateTime Date { get; set; }

        [Column(Order = 1)]
        public double CloseGrowth { get; set; }
    }
}
