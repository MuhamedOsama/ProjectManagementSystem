namespace ProjectManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingTeams : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Project_Id = c.Int(),
                        ProjectManager_Id = c.String(maxLength: 128),
                        TeamLeader_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.Project_Id)
                .ForeignKey("dbo.User", t => t.ProjectManager_Id)
                .ForeignKey("dbo.User", t => t.TeamLeader_Id)
                .Index(t => t.Project_Id)
                .Index(t => t.ProjectManager_Id)
                .Index(t => t.TeamLeader_Id);
            
            AddColumn("dbo.User", "Team_Id", c => c.Int());
            CreateIndex("dbo.User", "Team_Id");
            AddForeignKey("dbo.User", "Team_Id", "dbo.Teams", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "TeamLeader_Id", "dbo.User");
            DropForeignKey("dbo.Teams", "ProjectManager_Id", "dbo.User");
            DropForeignKey("dbo.Teams", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.User", "Team_Id", "dbo.Teams");
            DropIndex("dbo.Teams", new[] { "TeamLeader_Id" });
            DropIndex("dbo.Teams", new[] { "ProjectManager_Id" });
            DropIndex("dbo.Teams", new[] { "Project_Id" });
            DropIndex("dbo.User", new[] { "Team_Id" });
            DropColumn("dbo.User", "Team_Id");
            DropTable("dbo.Teams");
        }
    }
}
