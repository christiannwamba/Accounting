namespace Accounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmpIDType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.Orders", new[] { "EmployeeID" });
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Employees", "EmployeeID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Orders", "EmployeeID", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Employees", "EmployeeID");
            CreateIndex("dbo.Orders", "EmployeeID");
            AddForeignKey("dbo.Orders", "EmployeeID", "dbo.Employees", "EmployeeID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "EmployeeID", "dbo.Employees");
            DropIndex("dbo.Orders", new[] { "EmployeeID" });
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Orders", "EmployeeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "EmployeeID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Employees", "EmployeeID");
            CreateIndex("dbo.Orders", "EmployeeID");
            AddForeignKey("dbo.Orders", "EmployeeID", "dbo.Employees", "EmployeeID", cascadeDelete: true);
        }
    }
}
