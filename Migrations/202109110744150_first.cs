namespace HealthJang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentNo = c.Int(nullable: false, identity: true),
                        CommentContents = c.String(nullable: false),
                        UserNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentNo)
                .ForeignKey("dbo.Users", t => t.UserNo, cascadeDelete: true)
                .Index(t => t.UserNo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "UserNo", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "UserNo" });
            DropTable("dbo.Comments");
        }
    }
}
