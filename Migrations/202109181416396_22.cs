namespace HealthJang.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _22 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        MyProperty = c.Int(nullable: false, identity: true),
                        OrderNo = c.Int(nullable: false),
                        ProductNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MyProperty);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderNo = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        OrderStatus = c.String(nullable: false),
                        UserNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderNo);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductNo = c.Int(nullable: false, identity: true),
                        ProductImg = c.String(nullable: false),
                        ProductName = c.String(nullable: false),
                        ProductPrice = c.Int(nullable: false),
                        ProductDesc = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProductNo);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
        }
    }
}
