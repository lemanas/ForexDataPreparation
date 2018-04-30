namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuaterlyGrowthTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GbpUsdGrowthQuaterlies",
                c => new
                    {
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CloseGrowth = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.Date, t.CloseGrowth });
            
            CreateTable(
                "dbo.UsdGbpGrowthQuaterlies",
                c => new
                    {
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        CloseGrowth = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.Date, t.CloseGrowth });
        }
        
        public override void Down()
        {
            DropTable("dbo.UsdGbpGrowthQuaterlies");
            DropTable("dbo.UsdGbpGrowth");
            DropTable("dbo.UsdGbp");
            DropTable("dbo.GbpUsdGrowthQuaterlies");
            DropTable("dbo.GbpUsdGrowth");
            DropTable("dbo.GbpUsd");
        }
    }
}
