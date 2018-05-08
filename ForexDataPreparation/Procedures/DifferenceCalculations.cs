using System;
using System.Linq;
using ForexDataPreparation.Entities;
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
                        Quater = quater,
                        Difference = ukRate.Rate - usRate.Rate
                    };

                    context.CpiQuaterlyDifferences.Add(difference);
                }

                context.SaveChanges();
            }
        }

        public static void CalculateInterestRateDifferenceYearly()
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
