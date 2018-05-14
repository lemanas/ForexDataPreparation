using System;
using ForexDataPreparation.Enums;
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

                GrowthCalculations.CalculateForexGrowth(Period.Yearly, context.GbpUsd, context.GbpUsdGrowth);
                GrowthCalculations.CalculateForexGrowth(Period.Yearly, context.UsdGbp, context.UsdGbpGrowth);
                Console.WriteLine(@"Finished yearly growths");

                GrowthCalculations.CalculateForexGrowth(Period.Quaterly, context.GbpUsd, context.GbpUsdGrowthQuaterlies);
                GrowthCalculations.CalculateForexGrowth(Period.Quaterly, context.UsdGbp, context.UsdGbpGrowthQuaterlies);
                Console.WriteLine(@"Finished quaterly growths");

                DifferenceCalculations.CalculateCpiDifferenceYearly();
                DifferenceCalculations.CalculateCpiDifferenceQuaterly();
                Console.WriteLine(@"Finished CPI difference calculations");

                GrowthCalculations.CalculateDebtGrowth("UK");
                GrowthCalculations.CalculateDebtGrowth("USA");
                Console.WriteLine(@"Finished Debt of GDP growth calculations");

                DifferenceCalculations.CalculateInterestRateDifference(Period.Yearly);
                DifferenceCalculations.CalculateInterestRateDifference(Period.Quaterly);
                Console.WriteLine(@"Finished interest rate difference calculations");

                DifferenceCalculations.CalculateTradeBalance("UK");
                DifferenceCalculations.CalculateTradeBalance("USA");
                Console.WriteLine(@"Finished trade balance calculations");

                Console.WriteLine(@"Saving changes...");
                context.SaveChanges();

                AnalyticRecordCreator.UploadAnalyticRecords();
                AnalyticRecordCreator.UploadAnalyticQuarterlyRecords();
                Console.WriteLine(@"Finished uploading analytic records");
            }

        }
    }
}
