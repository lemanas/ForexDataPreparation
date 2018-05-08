namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CpiQtDiffTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "calc.CpiQuaterlyDifferences",
                c => new
                    {
                        Year = c.Int(nullable: false),
                        Quater = c.Int(nullable: false),
                        Difference = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.Year, t.Quater, t.Difference });
            
        }
        
        public override void Down()
        {
            DropTable("calc.CpiQuaterlyDifferences");
        }
    }
}
