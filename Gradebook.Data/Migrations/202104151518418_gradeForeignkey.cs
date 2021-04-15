namespace Gradebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gradeForeignkey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grade", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Grade", "StudentId");
            AddForeignKey("dbo.Grade", "StudentId", "dbo.Student", "StudentId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grade", "StudentId", "dbo.Student");
            DropIndex("dbo.Grade", new[] { "StudentId" });
            DropColumn("dbo.Grade", "StudentId");
        }
    }
}
