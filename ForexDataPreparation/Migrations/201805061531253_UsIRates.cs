namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsIRates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UsMonthlyInterestRates",
                c => new
                    {
                        Date = c.DateTime(nullable: false),
                        Rate = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.Date, t.Rate });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UsMonthlyInterestRates");
        }
    }
}
