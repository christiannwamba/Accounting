namespace Accounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ord : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "Order_OrderID", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "Order_OrderID" });
            RenameColumn(table: "dbo.OrderDetails", name: "Order_OrderID", newName: "OrderID");
            AlterColumn("dbo.OrderDetails", "OrderID", c => c.Int(nullable: false));
            CreateIndex("dbo.OrderDetails", "OrderID");
            AddForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders", "OrderID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "OrderID", "dbo.Orders");
            DropIndex("dbo.OrderDetails", new[] { "OrderID" });
            AlterColumn("dbo.OrderDetails", "OrderID", c => c.Int());
            RenameColumn(table: "dbo.OrderDetails", name: "OrderID", newName: "Order_OrderID");
            CreateIndex("dbo.OrderDetails", "Order_OrderID");
            AddForeignKey("dbo.OrderDetails", "Order_OrderID", "dbo.Orders", "OrderID");
        }
    }
}
