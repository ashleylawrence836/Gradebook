namespace Gradebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Grade", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Student", "OwnerId", c => c.Guid(nullable: false));
            AddColumn("dbo.Assignment", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Student", "OwnerId");
            DropColumn("dbo.Grade", "OwnerId");
            DropColumn("dbo.Course", "OwnerId");
            DropColumn("dbo.Assignment", "OwnerId");
        }
    }
}
