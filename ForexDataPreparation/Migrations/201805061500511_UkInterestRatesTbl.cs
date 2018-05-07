namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UkInterestRatesTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UkInterestRates",
                c => new
                    {
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Rate = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.Date, t.Rate });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UkInterestRates");
        }
    }
}
