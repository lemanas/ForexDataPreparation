using System;
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
                    AnalyticRecord record = new AnalyticRecord();
                    record.Id = i;
                    record.Year = year;
                    record.CpiDifference = cpiYearly[i].Difference;
                    record.CpiTendency = CalculateTendency(context.CpiQuaterlyDifferences.ToList(), year);
                    record.InterestRateDifference = context.InterestRateYearlyDifferences.Where(c => c.Year == year)
                        .Select(v => v.Difference).Single();
                    record.InterestRateTendency =
                        CalculateTendency(context.InterestRateQuaterlyDifferences.ToList(), year);
                    record.TradeBalanceByUk = context.TradeBalances.Where(c => c.Country == "UK" && c.Year == year)
                        .Select(v => v.Balance).Single();
                    record.TradeBalanceByUs = context.TradeBalances.Where(c => c.Country == "USA" && c.Year == year)
                        .Select(v => v.Balance).Single();
                    record.DebtGrowthUk = context.DebtGrowths.Where(c => c.Country == "UK" && c.Year == year)
                        .Select(v => v.Growth)
                        .Single();
                    record.DebtGrowthUs = context.DebtGrowths.Where(c => c.Country == "USA" && c.Year == year)
                        .Select(v => v.Growth)
                        .Single();
                    record.ForexTendency = context.GbpUsdGrowthQuaterlies.Where(y => y.Date.Year == year - 1)
                        .Select(v => v.CloseGrowth).Average();
                    record.Outcome = GetOutcomeLabel(context.GbpUsdGrowth.Where(y => y.Date.Year == year)
                        .Select(v => v.CloseGrowth).First());

                    context.AnalyticRecords.Add(record);
                }
                context.SaveChanges();
            }
        }

        public static void UploadAnalyticDailyRecords()
        {
            using (ForexModel context = new ForexModel())
            {
                var forexGrowths = context.GbpUsdGrowth.ToList();

                for (int i = 260; i < forexGrowths.Count; i++)
                {
                    var date = forexGrowths[i].Date;
                    var recDate = date.AddMonths(-3);
                    AnalyticDailyRecord record = new AnalyticDailyRecord();
                    record.Id = i;
                    record.Date = date;
                    record.CpiDifference = context.CpiYearlyDifferences.Where(d => d.Year == date.Year)
                        .Select(v => v.Difference).Single();
                    record.CpiTendency = CalculateTendency(context.CpiQuaterlyDifferences.ToList(), date.Year);
                    record.InterestRateDifference = context.InterestRateYearlyDifferences.Where(c => c.Year == date.Year)
                        .Select(v => v.Difference).Single();
                    record.InterestRateTendency = CalculateTendency(context.InterestRateQuaterlyDifferences.ToList(), date.Year);
                    record.TradeBalanceByUk = context.TradeBalances.Where(c => c.Country == "UK" && c.Year == date.Year)
                        .Select(v => v.Balance).Single();
                    record.TradeBalanceByUs = context.TradeBalances.Where(c => c.Country == "USA" && c.Year == date.Year)
                        .Select(v => v.Balance).Single();
                    record.DebtGrowthUk = context.DebtGrowths.Where(c => c.Country == "UK" && c.Year == date.Year)
                        .Select(v => v.Growth)
                        .Single();
                    record.DebtGrowthUs = context.DebtGrowths.Where(c => c.Country == "USA" && c.Year == date.Year)
                        .Select(v => v.Growth)
                        .Single();
                    record.ForexTendency = context.GbpUsdGrowth.Where(y => y.Date < date && y.Date > recDate)
                        .Select(v => v.CloseGrowth).Average();
                    record.Outcome = GetOutcomeLabel(forexGrowths.Where(d => d.Date == date).Select(v => v.CloseGrowth)
                        .Single());

                    context.AnalyticDailyRecords.Add(record);
                }
                context.SaveChanges();
            }
        }

        public static void UploadAnalyticQuarterlyRecords()
        {
            using (ForexModel context = new ForexModel())
            {
                var cpiQuarterly = context.CpiQuaterlyDifferences.ToList();
                var interestRateQuarterly = context.InterestRateQuaterlyDifferences.ToList();

                for (int i = 4; i < interestRateQuarterly.Count; i++)
                {
                    int year = interestRateQuarterly[i].Year;
                    int quarter = interestRateQuarterly[i].Quarter;
                    int eligibleMonth = DetermineEligibleStartMonth(quarter);
                    AnalyticQuarterlyRecord record = new AnalyticQuarterlyRecord
                    {
                        Id = i,
                        Year = year,
                        Quarter = quarter,
                        CpiDifference = cpiQuarterly[i].Difference,
                        CpiTendency = CalculateTendencyForQuarterly(cpiQuarterly, year + 1, quarter),
                        InterestRateDifference = interestRateQuarterly
                            .Where(c => c.Year == year && c.Quarter == quarter).Select(v => v.Difference).Single(),
                        InterestRateTendency = CalculateTendencyForQuarterly(interestRateQuarterly, year + 1, quarter),
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
                        ForexTendency = context.GbpUsdGrowthQuaterlies
                            .Where(y => y.Date.Year == year - 1 ||
                                        (y.Date.Year == year && y.Date.Month <= eligibleMonth))
                            .Select(v => v.CloseGrowth).Average(),
                        Outcome = GetOutcomeLabel(context.GbpUsdGrowthQuaterlies
                            .Where(y => y.Date.Year == year && y.Date.Month == eligibleMonth)
                            .Select(v => v.CloseGrowth).Single())
                    };


                    context.AnalyticQuarterlyRecords.Add(record);
                }
                context.SaveChanges();
            }
        }

        private static double CalculateTendency<T>(List<T> data, int year) where T : class, IQuarterly
        {
            return data.Where(y => y.Year == year - 1).Select(v => v.Difference).Average();
        }

        private static int DetermineEligibleStartMonth(int quarter)
        {
            return (quarter - 1) * 3 + 1;
        }

        private static double CalculateTendencyForQuarterly<T>(List<T> data, int year, int quarter) where T : class, IQuarterly
        {
            if (quarter == 1)
            {
                return data.Where(y => y.Year == year - 1).Select(v => v.Difference).Average();
            }
            if (quarter == 2)
            {
                double[] thisYear = data.Where(y => y.Year == year).Select(v => v.Difference).ToArray();
                double[] prevYear = data.Where(y => y.Year == year - 1 && y.Quarter > 1).Select(v => v.Difference).ToArray();
                return prevYear.Concat(thisYear).Average();
            }
            if (quarter == 3)
            {
                double[] thisYear = data.Where(y => y.Year == year).Select(v => v.Difference).ToArray();
                double[] prevYear = data.Where(y => y.Year == year - 1 && y.Quarter > 2).Select(v => v.Difference)
                    .ToArray();
                return prevYear.Concat(thisYear).Average();
            }
            else
            {
                double[] thisYear = data.Where(y => y.Year == year).Select(v => v.Difference).ToArray();
                double[] prevYear = data.Where(y => y.Year == year - 1 && y.Quarter > 3).Select(v => v.Difference)
                    .ToArray();
                return prevYear.Concat(thisYear).Average();
            }
        }

        private static Outcome GetOutcomeLabel(double value)
        {
            if (value >= 10) return Outcome.Fortunate;
            if (value < 10 && value >= 5) return Outcome.Positive;
            if (value > -10 && value <= -5) return Outcome.Negative;
            if (value < -10) return Outcome.Severe;
            return Outcome.Neutral;
        }
    }
}
