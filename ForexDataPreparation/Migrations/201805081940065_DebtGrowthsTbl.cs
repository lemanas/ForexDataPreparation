namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DebtGrowthsTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "calc.DebtGrowths",
                c => new
                    {
                        Country = c.String(nullable: false, maxLength: 128),
                        Year = c.Int(nullable: false),
                        Growth = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.Country, t.Year, t.Growth });
            
        }
        
        public override void Down()
        {
            DropTable("calc.DebtGrowths");
        }
    }
}
