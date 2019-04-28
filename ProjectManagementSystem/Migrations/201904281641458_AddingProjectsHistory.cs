namespace ProjectManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingProjectsHistory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectsHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        Status = c.Byte(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectsHistories", "User_Id", "dbo.User");
            DropIndex("dbo.ProjectsHistories", new[] { "User_Id" });
            DropTable("dbo.ProjectsHistories");
        }
    }
}
