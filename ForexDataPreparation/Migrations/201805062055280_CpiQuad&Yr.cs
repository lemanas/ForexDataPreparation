namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CpiQuadYr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CpiQuaterlyRates",
                c => new
                    {
                        Country = c.String(nullable: false, maxLength: 128),
                        Date = c.String(nullable: false, maxLength: 128),
                        Rate = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.Country, t.Date, t.Rate });
            
            CreateTable(
                "dbo.CpiYearlyRates",
                c => new
                    {
                        Country = c.String(nullable: false, maxLength: 128),
                        Date = c.String(nullable: false, maxLength: 128),
                        Rate = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.Country, t.Date, t.Rate });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CpiYearlyRates");
            DropTable("dbo.CpiQuaterlyRates");
        }
    }
}
