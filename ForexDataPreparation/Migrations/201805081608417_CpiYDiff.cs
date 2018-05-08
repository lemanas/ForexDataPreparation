namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CpiYDiff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "calc.CpiYearlyDifferences",
                c => new
                    {
                        Country = c.String(nullable: false, maxLength: 128),
                        Year = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.Country, t.Year, t.Rate });
            
        }
        
        public override void Down()
        {
            DropTable("calc.CpiYearlyDifferences");
        }
    }
}
