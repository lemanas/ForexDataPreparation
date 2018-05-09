using System.Collections.Generic;
using System.Linq;
using ForexDataPreparation.Entities;
using ForexDataPreparation.Enums;
using ForexDataPreparation.Interfaces;

namespace ForexDataPreparation.Procedures
{
    public class AnalyticRecordCreator
    {
        public static void UploadAnalyticRecords()
        {
            using (ForexModel context = new ForexModel())
            {
                var cpiYearly = context.CpiYearlyDifferences.ToList();
                for (int i = 1; i < cpiYearly.Count; i++)
                {
                    int year = cpiYearly[i].Year;
                    AnalyticRecord record = new AnalyticRecord
                    {
                        Year = year,
                        CpiDifference = cpiYearly[i].Difference,
                        CpiTendency = CalculateTendency(context.CpiQuaterlyDifferences.ToList(), year),
                        InterestRateDifference = context.InterestRateYearlyDifferences.Where(c => c.Year == year)
                            .Select(v => v.Difference).Single(),
                        InterestRateTendency =
                            CalculateTendency(context.InterestRateQuaterlyDifferences.ToList(), year),
                        TradeBalanceByUk = context.TradeBalances.Where(c => c.Country == "UK" && c.Year == year)
                            .Select(v => v.Balance).Single(),
                        TradeBalanceByUs = context.TradeBalances.Where(c => c.Country == "USA" && c.Year == year)
                            .Select(v => v.Balance).Single(),
                        DebtGrowthUk = context.DebtGrowths.Where(c => c.Country == "UK" && c.Year == year)
                            .Select(v => v.Growth)
                            .Single(),
                        DebtGrowthUs = context.DebtGrowths.Where(c => c.Country == "USA" && c.Year == year)
                            .Select(v => v.Growth)
                            .Single(),
                        ForexTendency = context.GbpUsdGrowthQuaterlies.Where(y => y.Date.Year == year - 1)
                            .Select(v => v.CloseGrowth).Average(),
                        Outcome = GetOutcomeLabel(context.GbpUsdGrowth.Where(y => y.Date.Year == year)
                            .Select(v => v.CloseGrowth).Single())
                    };

                    context.AnalyticRecords.Add(record);
                }
                context.SaveChanges();
            }
        }

        private static double CalculateTendency<T>(List<T> data, int year) where T : class, IQuarterly
        {
            return data.Where(y => y.Year == year - 1).Select(v => v.Difference).Average();
        }

        private static Outcome GetOutcomeLabel(double value)
        {
            if (value >= 10) return Outcome.Fortunate;
            if (value < 10 && value >= 2) return Outcome.Positive;
            if (value > -10 && value <= -2) return Outcome.Negative;
            if (value < -10) return Outcome.Severe;
            return Outcome.Neutral;
        }
    }
}
