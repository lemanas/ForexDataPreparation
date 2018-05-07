namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UndoLatestChanges : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UkInterestRates");
            AlterColumn("dbo.UkInterestRates", "Rate", c => c.Double(nullable: false));
            AddPrimaryKey("dbo.UkInterestRates", new[] { "Date", "Rate" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UkInterestRates");
            AlterColumn("dbo.UkInterestRates", "Rate", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.UkInterestRates", new[] { "Date", "Rate" });
        }
    }
}
