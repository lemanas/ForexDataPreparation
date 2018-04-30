using ForexDataPreparation.Procedures;

namespace ForexDataPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            GrowthCalculations.GetGbpUsdGrowth(1); // Daily GbpUsd - Done
            GrowthCalculations.GetUsdGbpGrowth(1); // Daily UsdGbp - Done

            //GrowthCalculations.GetGbpUsdGrowth(60); // Quater GbpUsd - Done
            //GrowthCalculations.GetUsdGbpGrowth(60); // Quater UsdGbp - Done
        }
    }
}
