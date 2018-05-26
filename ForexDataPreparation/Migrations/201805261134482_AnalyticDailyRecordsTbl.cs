namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnalyticDailyRecordsTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "calc.AnalyticDailyRecords",
                c => new
                    {
                        Date = c.DateTime(nullable: false),
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
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("calc.AnalyticDailyRecords");
        }
    }
}
