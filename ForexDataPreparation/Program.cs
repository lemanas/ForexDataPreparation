using System;
using ForexDataPreparation.Procedures;

namespace ForexDataPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ForexModel context = new ForexModel())
            {
                context.Configuration.AutoDetectChangesEnabled = false;

                context.Database.ExecuteSqlCommand("EXECUTE [dbo].[TruncateGrowths]");

                GrowthCalculations.CalculateForexGrowth(240, context.GbpUsd, context.GbpUsdGrowth);
                GrowthCalculations.CalculateForexGrowth(240, context.UsdGbp, context.UsdGbpGrowth);
                Console.WriteLine(@"Finished yearly growths");

                GrowthCalculations.CalculateForexGrowth(60, context.GbpUsd, context.GbpUsdGrowthQuaterlies);
                GrowthCalculations.CalculateForexGrowth(60, context.UsdGbp, context.UsdGbpGrowthQuaterlies);
                Console.WriteLine(@"Finished quaterly growths");

                DifferenceCalculations.CalculateCpiDifferenceYearly();
                DifferenceCalculations.CalculateCpiDifferenceQuaterly();
                Console.WriteLine(@"Finished CPI difference calculations");

                GrowthCalculations.CalculateDebtGrowth("UK");
                GrowthCalculations.CalculateDebtGrowth("USA");
                Console.WriteLine(@"Finished Debt of GDP growth calculations");

                DifferenceCalculations.CalculateInterestRateDifferenceYearly();

                Console.WriteLine(@"Saving changes...");
                context.SaveChanges();
            }

        }
    }
}
