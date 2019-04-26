namespace ProjectManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProfilePicture : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FileContentType = c.String(),
                        FilePath = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.User", "Photo_Id", c => c.Int());
            CreateIndex("dbo.User", "Photo_Id");
            AddForeignKey("dbo.User", "Photo_Id", "dbo.Photos", "Id");
            DropColumn("dbo.User", "Photo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "Photo", c => c.String());
            DropForeignKey("dbo.User", "Photo_Id", "dbo.Photos");
            DropIndex("dbo.User", new[] { "Photo_Id" });
            DropColumn("dbo.User", "Photo_Id");
            DropTable("dbo.Photos");
        }
    }
}
