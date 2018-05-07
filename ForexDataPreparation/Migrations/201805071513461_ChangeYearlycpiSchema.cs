namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeYearlycpiSchema : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.CpiYearlyRates", newSchema: "raw");
        }
        
        public override void Down()
        {
            MoveTable(name: "raw.CpiYearlyRates", newSchema: "dbo");
        }
    }
}
