namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCpiSchema : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.CpiQuaterlyRates", newSchema: "raw");
            MoveTable(name: "dbo.CpiRates", newSchema: "raw");
        }
        
        public override void Down()
        {
            MoveTable(name: "raw.CpiRates", newSchema: "dbo");
            MoveTable(name: "raw.CpiQuaterlyRates", newSchema: "dbo");
        }
    }
}
