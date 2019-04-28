namespace ProjectManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditedPhotoUserRelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.User", "Photo_Id", "dbo.Photos");
            DropIndex("dbo.User", new[] { "Photo_Id" });
            AddColumn("dbo.Photos", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Photos", "UserId");
            AddForeignKey("dbo.Photos", "UserId", "dbo.User", "Id");
            DropColumn("dbo.User", "Photo_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Photo_Id", c => c.Int());
            DropForeignKey("dbo.Photos", "UserId", "dbo.User");
            DropIndex("dbo.Photos", new[] { "UserId" });
            DropColumn("dbo.Photos", "UserId");
            CreateIndex("dbo.User", "Photo_Id");
            AddForeignKey("dbo.User", "Photo_Id", "dbo.Photos", "Id");
        }
    }
}
