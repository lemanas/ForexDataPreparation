namespace ForexDataPreparation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeAnalyticQTtblSchema : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.AnalyticQuarterlyRecords", newSchema: "calc");
        }
        
        public override void Down()
        {
            MoveTable(name: "calc.AnalyticQuarterlyRecords", newSchema: "dbo");
        }
    }
}
