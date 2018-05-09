using System;

namespace ForexDataPreparation.Interfaces
{
    public interface IGrowth : IDate
    {
        double CloseGrowth { get; set; }
    }
}
