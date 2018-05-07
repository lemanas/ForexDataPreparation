namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DboToCalc : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.GbpUsdGrowth", newSchema: "calc");
            MoveTable(name: "dbo.GbpUsdGrowthQuaterlies", newSchema: "calc");
            MoveTable(name: "dbo.UsdGbpGrowth", newSchema: "calc");
            MoveTable(name: "dbo.UsdGbpGrowthQuaterlies", newSchema: "calc");
        }
        
        public override void Down()
        {
            MoveTable(name: "calc.UsdGbpGrowthQuaterlies", newSchema: "dbo");
            MoveTable(name: "calc.UsdGbpGrowth", newSchema: "dbo");
            MoveTable(name: "calc.GbpUsdGrowthQuaterlies", newSchema: "dbo");
            MoveTable(name: "calc.GbpUsdGrowth", newSchema: "dbo");
        }
    }
}
