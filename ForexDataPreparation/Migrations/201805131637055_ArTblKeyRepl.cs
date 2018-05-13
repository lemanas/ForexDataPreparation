namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ArTblKeyRepl : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("calc.AnalyticRecords");
            AddColumn("calc.AnalyticRecords", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("calc.AnalyticRecords", "Year", c => c.Int(nullable: false));
            AddPrimaryKey("calc.AnalyticRecords", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("calc.AnalyticRecords");
            AlterColumn("calc.AnalyticRecords", "Year", c => c.Int(nullable: false, identity: true));
            DropColumn("calc.AnalyticRecords", "Id");
            AddPrimaryKey("calc.AnalyticRecords", "Year");
        }
    }
}
