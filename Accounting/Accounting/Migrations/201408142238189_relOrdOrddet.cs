namespace Accounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class relOrdOrddet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "Order_OrderID", c => c.Int());
            CreateIndex("dbo.OrderDetails", "Order_OrderID");
            AddForeignKey("dbo.OrderDetails", "Order_OrderID", "dbo.Orders", "OrderID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "Order_OrderID", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "Order_OrderID" });
            DropColumn("dbo.OrderDetails", "Order_OrderID");
        }
    }
}
