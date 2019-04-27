namespace ProjectManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelationshipForManagerAndProject : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ProjectManagerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Projects", "ProjectManagerId");
            AddForeignKey("dbo.Projects", "ProjectManagerId", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ProjectManagerId", "dbo.User");
            DropIndex("dbo.Projects", new[] { "ProjectManagerId" });
            DropColumn("dbo.Projects", "ProjectManagerId");
        }
    }
}
