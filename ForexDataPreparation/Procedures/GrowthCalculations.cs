using System;
using System.Data.Entity;
using System.Linq;
using ForexDataPreparation.Entities;
using ForexDataPreparation.Interfaces;

namespace ForexDataPreparation.Procedures
{
    public static class GrowthCalculations
    {
        public static void CalculateForexGrowth<T, TGrowth>(int periodByDays, DbSet<T> tentity, DbSet<TGrowth> tgrowth) where T : class, IRawData where TGrowth : class, IGrowth, new()
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

        public static void CalculateDebtGrowth(string country)
        {
            using (ForexModel context = new ForexModel())
            {
                var data = context.Debts.Where(c => c.Country == country).ToList();
                for (int i = 1; i < data.Count; i++)
                {
                    double currentValue = data[i].PercentageDebt;
                    double previousValue = data[i - 1].PercentageDebt;

                    var item = new DebtGrowth
                    {
                        Country = country,
                        Year = data[i].Year,
                        Growth = CalculateGrowth(previousValue, currentValue)
                    };

                    context.DebtGrowths.Add(item);
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
