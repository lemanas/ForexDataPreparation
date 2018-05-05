using System;

namespace ForexDataPreparation.Interfaces
{
    public interface IRawData
    {
        DateTime Date { get; set; }
        double Close { get; set; }
    }
}
