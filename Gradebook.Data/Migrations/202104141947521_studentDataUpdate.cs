namespace Gradebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentDataUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Student", "LastName", c => c.String(nullable: false));
            AddColumn("dbo.Student", "FullName", c => c.String());
            DropColumn("dbo.Student", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Student", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Student", "FullName");
            DropColumn("dbo.Student", "LastName");
            DropColumn("dbo.Student", "FirstName");
        }
    }
}
