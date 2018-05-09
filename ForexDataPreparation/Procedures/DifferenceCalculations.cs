using System;
using System.Linq;
using ForexDataPreparation.Entities;
using ForexDataPreparation.Enums;
using ForexDataPreparation.Helpers;
using ForexDataPreparation.Temporary_objects;

namespace ForexDataPreparation.Procedures
{
    public class DifferenceCalculations
    {
        public static void CalculateCpiDifferenceYearly()
        {
            using (ForexModel context = new ForexModel())
            {
                var ukRates = context.CpiYearlyRates.Where(c => c.Country == "\"GBR\"").OrderBy(y => y.Date).ToList();
                var usRates = context.CpiYearlyRates.Where(c => c.Country == "\"USA\"").OrderBy(y => y.Date).ToList();

                for (int i = 0; i < ukRates.Count; i++)
                {
                    CpiYearlyRate ukRate = ukRates[i];
                    CpiYearlyRate usRate = usRates[i];

                    var year = Int32.Parse(ukRate.Date.Substring(1, 4));

                    CpiYearlyDifference difference = new CpiYearlyDifference
                    {
                        Year = year,
                        Difference = ukRate.Rate - usRate.Rate
                    };

                    context.CpiYearlyDifferences.Add(difference);
                }

                context.SaveChanges();
            }
        }

        public static void CalculateCpiDifferenceQuaterly()
        {
            using (ForexModel context = new ForexModel())
            {
                var ukRates = context.CpiQuaterlyRates.Where(c => c.Country == "\"GBR\"").OrderBy(y => y.Date).ToList();
                var usRates = context.CpiQuaterlyRates.Where(c => c.Country == "\"USA\"").OrderBy(y => y.Date).ToList();

                for (int i = 0; i < ukRates.Count; i++)
                {
                    CpiQuaterlyRate ukRate = ukRates[i];
                    CpiQuaterlyRate usRate = usRates[i];

                    var year = Int32.Parse(ukRate.Date.Substring(1, 4));
                    var quater = Int32.Parse(ukRate.Date.Substring(7, 1));

                    CpiQuaterlyDifference difference = new CpiQuaterlyDifference
                    {
                        Year = year,
                        Quarter = quater,
                        Difference = ukRate.Rate - usRate.Rate
                    };

                    context.CpiQuaterlyDifferences.Add(difference);
                }

                context.SaveChanges();
            }
        }

        public static void CalculateInterestRateDifference(Period period)
        {
            using (ForexModel context = new ForexModel())
            {
                var ukDataRaw = context.UkInterestRates.ToList();

                var ukData = ukDataRaw.Select(v => new InterestRate
                {
                    Country = "UK",
                    Rate = v.Rate,
                    Date = ParseDate(v.Date)
                }).OrderBy(d => d.Date)
                  .ToList();

                var usData = context.UsMonthlyInterestRates.Select(v => new InterestRate
                {
                    Country = "USA",
                    Rate = v.Rate,
                    Date = v.Date
                }).ToList();

                int ukMinYear = ukData.Select(y => y.Date.Year).Min();
                int usMinYear = usData.Select(y => y.Date.Year).Min();
                int minYear = ukMinYear >= usMinYear ? ukMinYear : usMinYear;

                int ukMaxYear = ukData.Select(y => y.Date.Year).Max();
                int usMaxYear = usData.Select(y => y.Date.Year).Max();
                int maxYear = ukMaxYear <= usMaxYear ? ukMaxYear : usMaxYear;

                for (int i = minYear; i <= maxYear; i++)
                {
                    if (period == Period.Quaterly)
                    {
                        int month = 1;
                        for (int j = 1; j <= 4; j++)
                        {
                            if (!(i == 2017 && j > 1))
                            {

                                DateTime ukDate = DateHelpers.GetFirstAvailableDay(ukData, i, month);
                                DateTime usDate = DateHelpers.GetFirstAvailableDay(usData, i, month);

                                double ukRate = ukData.Where(d => d.Date == ukDate).Select(r => r.Rate).First();
                                double usRate = usData.Where(d => d.Date == usDate).Select(r => r.Rate).First();

                                InterestRateQuaterlyDifference difference = new InterestRateQuaterlyDifference
                                {
                                    Year = i,
                                    Quarter = j,
                                    Difference = ukRate - usRate
                                };

                                context.InterestRateQuaterlyDifferences.Add(difference);
                                month += 3;
                            }
                        }
                    }
                    else if (period == Period.Yearly)
                    {

                        DateTime ukDate = DateHelpers.GetFirstAvailableDay(ukData, i, 1);
                        DateTime usDate = DateHelpers.GetFirstAvailableDay(usData, i, 1);

                        double ukRate = ukData.Where(d => d.Date == ukDate).Select(r => r.Rate).First();
                        double usRate = usData.Where(d => d.Date == usDate).Select(r => r.Rate).First();

                        InterestRateYearlyDifference difference = new InterestRateYearlyDifference
                        {
                            Year = i,
                            Difference = ukRate - usRate
                        };

                        context.InterestRateYearlyDifferences.Add(difference);
                    }
                }

                context.SaveChanges();
            }
        }

        public static void CalculateTradeBalance(string country)
        {
            using (ForexModel context = new ForexModel())
            {
                var data = context.Trades.Where(c => c.Country == country);
                var exports = data.Where(f => f.Flow == 2).OrderBy(y => y.Year).ToList();
                var imports = data.Where(f => f.Flow == 1).OrderBy(y => y.Year).ToList();

                for (int i = 0; i < exports.Count; i++)
                {
                    TradeBalance balance = new TradeBalance
                    {
                        Country = country,
                        Year = exports[i].Year,
                        Balance = exports[i].Value - imports[i].Value
                    };

                    context.TradeBalances.Add(balance);
                }

                context.SaveChanges();
            }
        }

        private static DateTime ParseDate(string dateStr)
        {
            int day = Int32.Parse(dateStr.Substring(0, 2));
            int month = 13;
            int year = Int32.Parse(dateStr.Substring(7, 4));

            string monthAbbr = dateStr.Substring(3, 3);

            if (monthAbbr == "Jan") month = 1;
            if (monthAbbr == "Feb") month = 2;
            if (monthAbbr == "Mar") month = 3;
            if (monthAbbr == "Apr") month = 4;
            if (monthAbbr == "May") month = 5;
            if (monthAbbr == "Jun") month = 6;
            if (monthAbbr == "Jul") month = 7;
            if (monthAbbr == "Aug") month = 8;
            if (monthAbbr == "Sep") month = 9;
            if (monthAbbr == "Oct") month = 10;
            if (monthAbbr == "Nov") month = 11;
            if (monthAbbr == "Dec") month = 12;

            DateTime result = new DateTime(year, month, day);
            return result;
        }
    }
}
