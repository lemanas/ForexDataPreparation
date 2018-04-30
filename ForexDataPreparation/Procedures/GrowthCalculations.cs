using System;
using System.Collections.Generic;
using System.Linq;

namespace ForexDataPreparation.Procedures
{
    public static class GrowthCalculations
    {
        public static void GetGbpUsdGrowth()
        {
            using (ForexModel context = new ForexModel())
            {
                DateTime startDateTime = new DateTime(2000, 1, 1);
                var data = context.GbpUsd.Where(d => d.Date > startDateTime).ToList();
                var totalCount = data.Count - 1;
                for (int i = 1; i < data.Count; i++)
                {
                    DateTime currentDay = data[i].Date;

                    double currentPrice = data[i].Close;
                    double previousDayPrice = data[i - 1].Close;
                    double growth = CalculateGrowth(previousDayPrice, currentPrice);

                    var item = new GbpUsdGrowth
                    {
                        Date = currentDay,
                        CloseGrowth = growth
                    };
                    context.GbpUsdGrowth.Add(item);
                    Console.WriteLine($"{(i / totalCount) * 100} Completed");
                }
                context.SaveChanges();
            }
        }

        private static double CalculateGrowth(double previousValue, double currentValue)
        {
            double difference = currentValue - previousValue;
            return (difference / previousValue) * 100;
        }
    }
}
