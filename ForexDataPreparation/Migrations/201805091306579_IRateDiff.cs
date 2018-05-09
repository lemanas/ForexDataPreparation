namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IRateDiff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "calc.InterestRateYearlyDifferences",
                c => new
                    {
                        Year = c.Int(nullable: false),
                        Difference = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.Year, t.Difference });
            
        }
        
        public override void Down()
        {
            DropTable("calc.InterestRateYearlyDifferences");
        }
    }
}
