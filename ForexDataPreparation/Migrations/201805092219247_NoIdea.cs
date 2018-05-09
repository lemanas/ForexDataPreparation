namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NoIdea : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("calc.CpiQuaterlyDifferences");
            DropPrimaryKey("calc.InterestRateQuaterlyDifferences");
            AddColumn("calc.CpiQuaterlyDifferences", "Quarter", c => c.Int(nullable: false));
            AddColumn("calc.InterestRateQuaterlyDifferences", "Quarter", c => c.Int(nullable: false));
            AddPrimaryKey("calc.CpiQuaterlyDifferences", new[] { "Year", "Quarter", "Difference" });
            AddPrimaryKey("calc.InterestRateQuaterlyDifferences", new[] { "Year", "Quarter", "Difference" });
            DropColumn("calc.CpiQuaterlyDifferences", "Quater");
            DropColumn("calc.InterestRateQuaterlyDifferences", "Quater");
        }
        
        public override void Down()
        {
            AddColumn("calc.InterestRateQuaterlyDifferences", "Quater", c => c.Int(nullable: false));
            AddColumn("calc.CpiQuaterlyDifferences", "Quater", c => c.Int(nullable: false));
            DropPrimaryKey("calc.InterestRateQuaterlyDifferences");
            DropPrimaryKey("calc.CpiQuaterlyDifferences");
            DropColumn("calc.InterestRateQuaterlyDifferences", "Quarter");
            DropColumn("calc.CpiQuaterlyDifferences", "Quarter");
            AddPrimaryKey("calc.InterestRateQuaterlyDifferences", new[] { "Year", "Quater", "Difference" });
            AddPrimaryKey("calc.CpiQuaterlyDifferences", new[] { "Year", "Quater", "Difference" });
        }
    }
}
