namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TradeTblAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "raw.Trade",
                c => new
                    {
                        Country = c.String(nullable: false, maxLength: 128),
                        Partner = c.String(nullable: false, maxLength: 128),
                        Flow = c.Int(nullable: false),
                        Year = c.DateTime(nullable: false),
                        Value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.Country, t.Partner, t.Flow, t.Year, t.Value });
            
        }
        
        public override void Down()
        {
            DropTable("raw.Trade");
        }
    }
}
