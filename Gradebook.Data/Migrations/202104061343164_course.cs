namespace Gradebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class course : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course", "StartDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Course", "EndDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Course", "EndDate");
            DropColumn("dbo.Course", "StartDate");
        }
    }
}
