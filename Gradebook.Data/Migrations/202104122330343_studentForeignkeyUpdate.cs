namespace Gradebook.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentForeignkeyUpdate : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Assignment", "CourseId");
            AddForeignKey("dbo.Assignment", "CourseId", "dbo.Course", "CourseId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assignment", "CourseId", "dbo.Course");
            DropIndex("dbo.Assignment", new[] { "CourseId" });
        }
    }
}
