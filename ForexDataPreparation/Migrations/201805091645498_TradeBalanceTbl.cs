namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TradeBalanceTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "calc.TradeBalances",
                c => new
                    {
                        Country = c.String(nullable: false, maxLength: 128),
                        Year = c.Int(nullable: false),
                        Balance = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.Country, t.Year, t.Balance });
            
        }
        
        public override void Down()
        {
            DropTable("calc.TradeBalances");
        }
    }
}
