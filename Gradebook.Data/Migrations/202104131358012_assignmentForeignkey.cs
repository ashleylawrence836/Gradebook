namespace Gradebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class assignmentForeignkey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assignment", "DueDate", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assignment", "DueDate");
        }
    }
}
