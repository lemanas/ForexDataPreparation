namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DebtsTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "raw.Debts",
                c => new
                    {
                        Country = c.String(nullable: false, maxLength: 128),
                        Year = c.Int(nullable: false),
                        PercentageDebt = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.Country, t.Year, t.PercentageDebt });
            
        }
        
        public override void Down()
        {
            DropTable("raw.Debts");
        }
    }
}
