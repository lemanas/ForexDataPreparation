using System;
using System.Collections.Generic;
using System.Linq;
using ForexDataPreparation.Interfaces;

namespace ForexDataPreparation.Helpers
{
    public static class DateHelpers
    {
        public static DateTime GetFirstDay<T>(this List<T> data, int year) where T : class, IRawData
        {
            return data.Where(day => day.Date.Year == year).Min().Date;
        }

        public static DateTime GetFirstAvailableDay<T>(List<T> data, int year, int month) where T : class, IDate
        {
            return data.Where(d => d.Date.Year == year && d.Date.Month == month).Min().Date;
        }
    }
}
