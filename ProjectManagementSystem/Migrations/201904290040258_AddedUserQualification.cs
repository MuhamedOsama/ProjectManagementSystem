namespace ProjectManagementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserQualification : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Qualifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        English = c.Byte(nullable: false),
                        Leadership = c.Byte(nullable: false),
                        Communication = c.Byte(nullable: false),
                        Creativity = c.Byte(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Qualifications", "UserId", "dbo.User");
            DropIndex("dbo.Qualifications", new[] { "UserId" });
            DropTable("dbo.Qualifications");
        }
    }
}
