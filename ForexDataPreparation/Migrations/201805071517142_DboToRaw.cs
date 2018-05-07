namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DboToRaw : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.GbpUsd", newSchema: "raw");
            MoveTable(name: "dbo.UkInterestRates", newSchema: "raw");
            MoveTable(name: "dbo.UsdGbp", newSchema: "raw");
            MoveTable(name: "dbo.UsMonthlyInterestRates", newSchema: "raw");
        }
        
        public override void Down()
        {
            MoveTable(name: "raw.UsMonthlyInterestRates", newSchema: "dbo");
            MoveTable(name: "raw.UsdGbp", newSchema: "dbo");
            MoveTable(name: "raw.UkInterestRates", newSchema: "dbo");
            MoveTable(name: "raw.GbpUsd", newSchema: "dbo");
        }
    }
}
