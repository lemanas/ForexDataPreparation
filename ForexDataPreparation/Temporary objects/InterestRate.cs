using System;
using ForexDataPreparation.Interfaces;

namespace ForexDataPreparation.Temporary_objects
{
    public class InterestRate : IDate, IRawData
    {
        public string Country { get; set; }
        public DateTime Date { get; set; }
        public double Rate { get; set; }
        public double Close { get; set; }
    }
}
