using System;
using System.Data.Entity;
using System.Linq;
using ForexDataPreparation.Interfaces;

namespace ForexDataPreparation.Procedures
{
    public static class GrowthCalculations
    {
        public static void GetGrowth<T, TGrowth>(int periodByDays, DbSet<T> tentity, DbSet<TGrowth> tgrowth) where T : class, IRawData where TGrowth : class, IGrowth, new()
        {
            DateTime startDateTime = new DateTime(2000, 1, 1);
            var data = tentity.Where(d => d.Date > startDateTime).ToList();
            for (int i = periodByDays; i < data.Count; i += periodByDays)
            {
                DateTime currentDay = data[i].Date;

                double currentPrice = data[i].Close;
                double previousDayPrice = data[i - periodByDays].Close;
                double growth = CalculateGrowth(previousDayPrice, currentPrice);

                var item = new TGrowth
                {
                    Date = currentDay,
                    CloseGrowth = growth
                };
                tgrowth.Add(item);
            }
        }

        private static double CalculateGrowth(double previousValue, double currentValue)
        {
            double difference = currentValue - previousValue;
            return (difference / previousValue) * 100;
        }
    }
}
