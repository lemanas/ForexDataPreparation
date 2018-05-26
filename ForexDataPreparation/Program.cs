using System;
using ForexDataPreparation.Enums;
using ForexDataPreparation.Procedures;

namespace ForexDataPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (ForexModel context = new ForexModel())
            //{
            //    context.Configuration.AutoDetectChangesEnabled = false;

            //    context.Database.ExecuteSqlCommand("EXECUTE [dbo].[TruncateGrowths]");

            //    GrowthCalculations.CalculateForexGrowth(Period.Daily, context.GbpUsd, context.GbpUsdGrowth);
            //    Console.WriteLine(@"Finished yearly growths");

            //    GrowthCalculations.CalculateForexGrowth(Period.Quaterly, context.GbpUsd,
            //        context.GbpUsdGrowthQuaterlies);
            //    Console.WriteLine(@"Finished quaterly growths");

            //    Console.WriteLine(@"Saving changes...");
            //    context.SaveChanges();
            //    Console.WriteLine(@"Saved changes");
            //}

            //DifferenceCalculations.CalculateCpiDifferenceYearly();
            //DifferenceCalculations.CalculateCpiDifferenceQuaterly();
            //Console.WriteLine(@"Finished CPI difference calculations");

            //GrowthCalculations.CalculateDebtGrowth("UK");
            //GrowthCalculations.CalculateDebtGrowth("USA");
            //Console.WriteLine(@"Finished Debt of GDP growth calculations");

            //DifferenceCalculations.CalculateInterestRateDifference(Period.Yearly);
            //DifferenceCalculations.CalculateInterestRateDifference(Period.Quaterly);
            //Console.WriteLine(@"Finished interest rate difference calculations");

            //DifferenceCalculations.CalculateTradeBalance("UK");
            //DifferenceCalculations.CalculateTradeBalance("USA");
            //Console.WriteLine(@"Finished trade balance calculations");

            //AnalyticRecordCreator.UploadAnalyticRecords();
            //AnalyticRecordCreator.UploadAnalyticQuarterlyRecords();
            AnalyticRecordCreator.UploadAnalyticDailyRecords();
            Console.WriteLine(@"Finished uploading analytic records");


        }
    }
}
