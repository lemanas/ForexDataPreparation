namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnalyticTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "calc.AnalyticRecords",
                c => new
                    {
                        Year = c.Int(nullable: false),
                        CpiDifference = c.Double(nullable: false),
                        CpiTendency = c.Double(nullable: false),
                        InterestRateDifference = c.Double(nullable: false),
                        InterestRateTendency = c.Double(nullable: false),
                        TradeBalanceByUk = c.Double(nullable: false),
                        TradeBalanceByUs = c.Double(nullable: false),
                        DebtGrowthUk = c.Double(nullable: false),
                        DebtGrowthUs = c.Double(nullable: false),
                        ForexTendency = c.Double(nullable: false),
                        Outcome = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Year, t.CpiDifference, t.CpiTendency, t.InterestRateDifference, t.InterestRateTendency, t.TradeBalanceByUk, t.TradeBalanceByUs, t.DebtGrowthUk, t.DebtGrowthUs, t.ForexTendency, t.Outcome });
            
        }
        
        public override void Down()
        {
            DropTable("calc.AnalyticRecords");
        }
    }
}
