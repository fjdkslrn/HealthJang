namespace HealthJang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "BoardNo", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "BoardNo");
            AddForeignKey("dbo.Comments", "BoardNo", "dbo.Boards", "BoardNo", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "BoardNo", "dbo.Boards");
            DropIndex("dbo.Comments", new[] { "BoardNo" });
            DropColumn("dbo.Comments", "BoardNo");
        }
    }
}
