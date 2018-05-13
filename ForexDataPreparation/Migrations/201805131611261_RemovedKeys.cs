namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedKeys : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("calc.AnalyticRecords");
            DropPrimaryKey("calc.CpiQuaterlyDifferences");
            DropPrimaryKey("calc.CpiYearlyDifferences");
            DropPrimaryKey("calc.DebtGrowths");
            DropPrimaryKey("raw.Debts");
            DropPrimaryKey("calc.InterestRateQuaterlyDifferences");
            DropPrimaryKey("calc.InterestRateYearlyDifferences");
            DropPrimaryKey("calc.TradeBalances");
            DropPrimaryKey("raw.Trade");
            AlterColumn("calc.AnalyticRecords", "Year", c => c.Int(nullable: false, identity: true));
            AlterColumn("calc.CpiYearlyDifferences", "Year", c => c.Int(nullable: false, identity: true));
            AlterColumn("calc.InterestRateYearlyDifferences", "Year", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("calc.AnalyticRecords", "Year");
            AddPrimaryKey("calc.CpiQuaterlyDifferences", new[] { "Year", "Quarter" });
            AddPrimaryKey("calc.CpiYearlyDifferences", "Year");
            AddPrimaryKey("calc.DebtGrowths", new[] { "Country", "Year" });
            AddPrimaryKey("raw.Debts", new[] { "Country", "Year" });
            AddPrimaryKey("raw.GbpUsd", "Date");
            AddPrimaryKey("calc.GbpUsdGrowth", "Date");
            AddPrimaryKey("calc.InterestRateQuaterlyDifferences", new[] { "Year", "Quarter" });
            AddPrimaryKey("calc.InterestRateYearlyDifferences", "Year");
            AddPrimaryKey("calc.TradeBalances", new[] { "Country", "Year" });
            AddPrimaryKey("raw.Trade", new[] { "Country", "Partner", "Flow", "Year" });
            AddPrimaryKey("raw.UsdGbp", "Date");
            AddPrimaryKey("calc.UsdGbpGrowth", "Date");
        }
        
        public override void Down()
        {
            DropPrimaryKey("raw.UsMonthlyInterestRates");
            DropPrimaryKey("calc.UsdGbpGrowthQuaterlies");
            DropPrimaryKey("calc.UsdGbpGrowth");
            DropPrimaryKey("raw.UsdGbp");
            DropPrimaryKey("raw.UkInterestRates");
            DropPrimaryKey("raw.Trade");
            DropPrimaryKey("calc.TradeBalances");
            DropPrimaryKey("calc.InterestRateYearlyDifferences");
            DropPrimaryKey("calc.InterestRateQuaterlyDifferences");
            DropPrimaryKey("calc.GbpUsdGrowthQuaterlies");
            DropPrimaryKey("calc.GbpUsdGrowth");
            DropPrimaryKey("raw.GbpUsd");
            DropPrimaryKey("raw.Debts");
            DropPrimaryKey("calc.DebtGrowths");
            DropPrimaryKey("raw.CpiYearlyRates");
            DropPrimaryKey("calc.CpiYearlyDifferences");
            DropPrimaryKey("raw.CpiRates");
            DropPrimaryKey("calc.CpiQuaterlyDifferences");
            DropPrimaryKey("calc.AnalyticRecords");
            AlterColumn("calc.InterestRateYearlyDifferences", "Year", c => c.Int(nullable: false));
            AlterColumn("calc.CpiYearlyDifferences", "Year", c => c.Int(nullable: false));
            AlterColumn("calc.AnalyticRecords", "Year", c => c.Int(nullable: false));
            AddPrimaryKey("raw.UsMonthlyInterestRates", new[] { "Date", "Rate" });
            AddPrimaryKey("calc.UsdGbpGrowthQuaterlies", new[] { "Date", "CloseGrowth" });
            AddPrimaryKey("calc.UsdGbpGrowth", new[] { "Date", "CloseGrowth" });
            AddPrimaryKey("raw.UsdGbp", new[] { "Date", "Open", "High", "Low", "Close", "Volume", "OpenInt" });
            AddPrimaryKey("raw.UkInterestRates", new[] { "Date", "Rate" });
            AddPrimaryKey("raw.Trade", new[] { "Country", "Partner", "Flow", "Year", "Value" });
            AddPrimaryKey("calc.TradeBalances", new[] { "Country", "Year", "Balance" });
            AddPrimaryKey("calc.InterestRateYearlyDifferences", new[] { "Year", "Difference" });
            AddPrimaryKey("calc.InterestRateQuaterlyDifferences", new[] { "Year", "Quarter", "Difference" });
            AddPrimaryKey("calc.GbpUsdGrowthQuaterlies", new[] { "Date", "CloseGrowth" });
            AddPrimaryKey("calc.GbpUsdGrowth", new[] { "Date", "CloseGrowth" });
            AddPrimaryKey("raw.GbpUsd", new[] { "Date", "Open", "High", "Low", "Close", "Volume", "OpenInt" });
            AddPrimaryKey("raw.Debts", new[] { "Country", "Year", "PercentageDebt" });
            AddPrimaryKey("calc.DebtGrowths", new[] { "Country", "Year", "Growth" });
            AddPrimaryKey("raw.CpiYearlyRates", new[] { "Country", "Date", "Rate" });
            AddPrimaryKey("calc.CpiYearlyDifferences", new[] { "Year", "Difference" });
            AddPrimaryKey("raw.CpiRates", new[] { "Country", "Date", "Rate" });
            AddPrimaryKey("calc.CpiQuaterlyDifferences", new[] { "Year", "Quarter", "Difference" });
            AddPrimaryKey("calc.AnalyticRecords", new[] { "Year", "CpiDifference", "CpiTendency", "InterestRateDifference", "InterestRateTendency", "TradeBalanceByUk", "TradeBalanceByUs", "DebtGrowthUk", "DebtGrowthUs", "ForexTendency", "Outcome" });
        }
    }
}
