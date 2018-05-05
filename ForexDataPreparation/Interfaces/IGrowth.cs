using System;

namespace ForexDataPreparation.Interfaces
{
    public interface IGrowth
    {
        DateTime Date { get; set; }
        double CloseGrowth { get; set; }
    }
}
