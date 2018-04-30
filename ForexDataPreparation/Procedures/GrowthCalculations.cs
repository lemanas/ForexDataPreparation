using System;
using System.Linq;
using ForexDataPreparation.Entities;

namespace ForexDataPreparation.Procedures
{
    public static class GrowthCalculations
    {
        public static void GetGbpUsdGrowth(int periodByDays)
        {
            using (ForexModel context = new ForexModel())
            {
                DateTime startDateTime = new DateTime(2000, 1, 1);
                var data = context.GbpUsd.Where(d => d.Date > startDateTime).ToList();
                var totalCount = data.Count - 1;
                for (int i = periodByDays; i < data.Count; i += periodByDays)
                {
                    DateTime currentDay = data[i].Date;

                    double currentPrice = data[i].Close;
                    double previousDayPrice = data[i - periodByDays].Close;
                    double growth = CalculateGrowth(previousDayPrice, currentPrice);

                    var item = new GbpUsdGrowth
                    {
                        Date = currentDay,
                        CloseGrowth = growth
                    };
                    context.GbpUsdGrowth.Add(item);
                    Console.Write($"\r{i} / {totalCount}");
                }
                context.SaveChanges();
            }
        }

        public static void GetUsdGbpGrowth(int periodByDays)
        {
            using (ForexModel context = new ForexModel())
            {
                DateTime startDateTime = new DateTime(2000, 1, 1);
                var data = context.UsdGbp.Where(d => d.Date > startDateTime).ToList();
                var totalCount = data.Count - 1;
                for (int i = periodByDays; i < data.Count; i += periodByDays)
                {
                    DateTime currentDay = data[i].Date;

                    double currentPrice = data[i].Close;
                    double previousDayPrice = data[i - periodByDays].Close;
                    double growth = CalculateGrowth(previousDayPrice, currentPrice);

                    var item = new UsdGbpGrowth
                    {
                        Date = currentDay,
                        CloseGrowth = growth
                    };
                    context.UsdGbpGrowth.Add(item);
                    Console.Write($"\r{i} / {totalCount}");
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
