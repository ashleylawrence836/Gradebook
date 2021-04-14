namespace Gradebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gradeForeignkeyUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Grade", "CourseId", "dbo.Course");
            DropIndex("dbo.Grade", new[] { "CourseId" });
            AddColumn("dbo.Grade", "AssignmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Grade", "AssignmentId");
            AddForeignKey("dbo.Grade", "AssignmentId", "dbo.Assignment", "AssignmentId", cascadeDelete: true);
            DropColumn("dbo.Grade", "CourseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Grade", "CourseId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Grade", "AssignmentId", "dbo.Assignment");
            DropIndex("dbo.Grade", new[] { "AssignmentId" });
            DropColumn("dbo.Grade", "AssignmentId");
            CreateIndex("dbo.Grade", "CourseId");
            AddForeignKey("dbo.Grade", "CourseId", "dbo.Course", "CourseId", cascadeDelete: true);
        }
    }
}
