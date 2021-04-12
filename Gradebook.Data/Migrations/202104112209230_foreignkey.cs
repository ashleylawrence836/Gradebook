namespace Gradebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Student", "CourseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Student", "CourseId");
            AddForeignKey("dbo.Student", "CourseId", "dbo.Course", "CourseId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Student", "CourseId", "dbo.Course");
            DropIndex("dbo.Student", new[] { "CourseId" });
            DropColumn("dbo.Student", "CourseId");
        }
    }
}
