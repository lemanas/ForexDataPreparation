namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class KeysReplaced : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("calc.CpiQuaterlyDifferences");
            DropPrimaryKey("calc.CpiYearlyDifferences");
            AddColumn("calc.CpiQuaterlyDifferences", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("calc.CpiYearlyDifferences", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("calc.CpiYearlyDifferences", "Year", c => c.Int(nullable: false));
            AddPrimaryKey("calc.CpiQuaterlyDifferences", "Id");
            AddPrimaryKey("calc.CpiYearlyDifferences", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("calc.CpiYearlyDifferences");
            DropPrimaryKey("raw.CpiQuaterlyRates");
            DropPrimaryKey("calc.CpiQuaterlyDifferences");
            AlterColumn("calc.CpiYearlyDifferences", "Year", c => c.Int(nullable: false, identity: true));
            DropColumn("calc.CpiYearlyDifferences", "Id");
            DropColumn("calc.CpiQuaterlyDifferences", "Id");
            AddPrimaryKey("calc.CpiYearlyDifferences", "Year");
            AddPrimaryKey("raw.CpiQuaterlyRates", new[] { "Country", "Date", "Rate" });
            AddPrimaryKey("calc.CpiQuaterlyDifferences", new[] { "Year", "Quarter" });
        }
    }
}
