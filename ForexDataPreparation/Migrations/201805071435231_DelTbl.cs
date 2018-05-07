namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DelTbl : DbMigration
    {
        public override void Up()
        {
            DropTable("raw.Trade");
        }
        
        public override void Down()
        {
            CreateTable(
                "raw.Trade",
                c => new
                    {
                        Country = c.String(nullable: false, maxLength: 128),
                        Partner = c.String(nullable: false, maxLength: 128),
                        Flow = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        Value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.Country, t.Partner, t.Flow, t.Year, t.Value });
            
        }
    }
}
