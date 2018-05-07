namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateString : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UkInterestRates");
            AlterColumn("dbo.UkInterestRates", "Date", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.UkInterestRates", new[] { "Date", "Rate" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UkInterestRates");
            AlterColumn("dbo.UkInterestRates", "Date", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddPrimaryKey("dbo.UkInterestRates", new[] { "Date", "Rate" });
        }
    }
}
