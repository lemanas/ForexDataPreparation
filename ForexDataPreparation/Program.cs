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

                GrowthCalculations.GetGrowth(240, context.GbpUsd, context.GbpUsdGrowth);
                GrowthCalculations.GetGrowth(240, context.UsdGbp, context.UsdGbpGrowth);
                Console.WriteLine(@"Finished yearly growths");

                GrowthCalculations.GetGrowth(60, context.GbpUsd, context.GbpUsdGrowthQuaterlies);
                GrowthCalculations.GetGrowth(60, context.UsdGbp, context.UsdGbpGrowthQuaterlies);
                Console.WriteLine(@"Finished quaterly growths");

                Console.WriteLine(@"Saving changes...");
                context.SaveChanges();
            }

        }
    }
}
