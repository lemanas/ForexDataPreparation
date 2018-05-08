namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CpiDiffChange : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("calc.CpiYearlyDifferences");
            AddColumn("calc.CpiYearlyDifferences", "Difference", c => c.Double(nullable: false));
            AddPrimaryKey("calc.CpiYearlyDifferences", new[] { "Year", "Difference" });
            DropColumn("calc.CpiYearlyDifferences", "Country");
            DropColumn("calc.CpiYearlyDifferences", "Rate");
        }
        
        public override void Down()
        {
            AddColumn("calc.CpiYearlyDifferences", "Rate", c => c.Double(nullable: false));
            AddColumn("calc.CpiYearlyDifferences", "Country", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("calc.CpiYearlyDifferences");
            DropColumn("calc.CpiYearlyDifferences", "Difference");
            AddPrimaryKey("calc.CpiYearlyDifferences", new[] { "Country", "Year", "Rate" });
        }
    }
}
