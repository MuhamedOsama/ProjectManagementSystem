namespace ProjectManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamingForeignKeyPropertyInProjects : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Projects", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Projects", name: "IX_User_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Projects", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Projects", name: "UserId", newName: "User_Id");
        }
    }
}
