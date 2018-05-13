namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InterestRateKeyRep : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("calc.InterestRateQuaterlyDifferences");
            DropPrimaryKey("calc.InterestRateYearlyDifferences");
            AddColumn("calc.InterestRateQuaterlyDifferences", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("calc.InterestRateYearlyDifferences", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("calc.InterestRateYearlyDifferences", "Year", c => c.Int(nullable: false));
            AddPrimaryKey("calc.InterestRateQuaterlyDifferences", "Id");
            AddPrimaryKey("calc.InterestRateYearlyDifferences", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("calc.InterestRateYearlyDifferences");
            DropPrimaryKey("calc.InterestRateQuaterlyDifferences");
            AlterColumn("calc.InterestRateYearlyDifferences", "Year", c => c.Int(nullable: false, identity: true));
            DropColumn("calc.InterestRateYearlyDifferences", "Id");
            DropColumn("calc.InterestRateQuaterlyDifferences", "Id");
            AddPrimaryKey("calc.InterestRateYearlyDifferences", "Year");
            AddPrimaryKey("calc.InterestRateQuaterlyDifferences", new[] { "Year", "Quarter" });
        }
    }
}
