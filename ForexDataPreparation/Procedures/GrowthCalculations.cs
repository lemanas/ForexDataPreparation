using System;
using System.Data.Entity;
using System.Linq;
using ForexDataPreparation.Entities;
using ForexDataPreparation.Enums;
using ForexDataPreparation.Helpers;
using ForexDataPreparation.Interfaces;

namespace ForexDataPreparation.Procedures
{
    public static class GrowthCalculations
    {
        public static void CalculateForexGrowth<T, TGrowth>(Period period, DbSet<T> tentity, DbSet<TGrowth> tgrowth) where T : class, IRawData where TGrowth : class, IGrowth, new()
        {
            DateTime startDateTime = new DateTime(1999, 1, 1);
            var data = tentity.Where(d => d.Date > startDateTime).ToList();

            int minYear = data.Select(d => d.Date.Year).Min();
            int maxYear = data.Select(d => d.Date.Year).Max();

            for (int i = minYear + 1; i <= maxYear; i++)
            {
                if (period == Period.Yearly)
                {
                    DateTime currentDay = DateHelpers.GetFirstAvailableDay(data, i, 1);
                    DateTime previousDay = DateHelpers.GetFirstAvailableDay(data, i-1, 1);

                    double currentPrice = data.Where(d => d.Date == currentDay).Select(v => v.Close).First();
                    double previousDayPrice = data.Where(d => d.Date == previousDay).Select(v => v.Close).First();
                    double growth = CalculateGrowth(previousDayPrice, currentPrice);

                    var item = new TGrowth
                    {
                        Date = currentDay,
                        CloseGrowth = growth
                    };
                    tgrowth.Add(item);
                }
                else if (period == Period.Quaterly)
                {
                    int month = 1;
                    for (int j = 1; j <= 4; j++)
                    {
                        DateTime currentDay = DateHelpers.GetFirstAvailableDay(data, i, month);
                        var previousDay = month != 1 ? DateHelpers.GetFirstAvailableDay(data, i, month - 3) : DateHelpers.GetFirstAvailableDay(data, i - 1, 10);

                        double currentPrice = data.Where(d => d.Date == currentDay).Select(v => v.Close).First();
                        double previousDayPrice = data.Where(d => d.Date == previousDay).Select(v => v.Close).First();
                        double growth = CalculateGrowth(previousDayPrice, currentPrice);

                        var item = new TGrowth
                        {
                            Date = currentDay,
                            CloseGrowth = growth
                        };
                        tgrowth.Add(item);
                        month += 3;
                    }
                }
            }
            if (period == Period.Daily)
            {
                for (int i = 261; i < data.Count; i++)
                {
                    DateTime currentDay = data[i].Date;
                    DateTime previousDay = currentDay.AddYears(-1);
                    if (previousDay.DayOfWeek == DayOfWeek.Saturday) previousDay = previousDay.AddDays(2);
                    if (previousDay.DayOfWeek == DayOfWeek.Sunday) previousDay = previousDay.AddDays(1);

                    double currentPrice = data[i].Close;
                    double previousDayPrice = data.Where(d => d.Date == previousDay).Select(v => v.Close).SingleOrDefault();
                    double growth = CalculateGrowth(previousDayPrice, currentPrice);

                    if (growth != 0)
                    {
                        var item = new TGrowth
                        {
                            Date = currentDay,
                            CloseGrowth = growth
                        };
                        tgrowth.Add(item);
                    }
                }
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
            if (previousValue == 0) return 0;
            double difference = currentValue - previousValue;
            return (difference / previousValue) * 100;
        }
    }
}
