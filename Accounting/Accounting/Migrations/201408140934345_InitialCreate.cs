namespace Accounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false),
                        QuantityPerUnit = c.String(),
                        UnitPrice = c.Decimal(nullable: false, storeType: "money"),
                        UnitInStock = c.Int(nullable: false),
                        UnitInOrder = c.Int(nullable: false),
                        ReorderLevel = c.Int(nullable: false),
                        ProductDescription = c.String(),
                        Remarks = c.String(),
                        CategoryID = c.Int(nullable: false),
                        SupplierID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierID, cascadeDelete: true)
                .Index(t => t.CategoryID)
                .Index(t => t.SupplierID);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailID = c.Int(nullable: false, identity: true),
                        UnitPrice = c.Decimal(nullable: false, storeType: "money"),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                        Remarks = c.String(),
                        ProductID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityID = c.Int(nullable: false, identity: true),
                        CityName = c.String(nullable: false),
                        SatteID = c.Int(nullable: false),
                        State_StateID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CityID)
                .ForeignKey("dbo.States", t => t.State_StateID, cascadeDelete: true)
                .Index(t => t.State_StateID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false),
                        FirstName = c.String(nullable: false),
                        Lastname = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                        Address = c.String(maxLength: 200),
                        Email = c.String(),
                        Phone = c.Int(nullable: false),
                        PhotoPath = c.String(maxLength: 300),
                        CityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.Cities", t => t.CityID, cascadeDelete: true)
                .Index(t => t.CityID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        RequiredDate = c.DateTime(nullable: false),
                        Ordered = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        EmployeeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Employees", t => t.EmployeeID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.EmployeeID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 100),
                        ContactName = c.String(maxLength: 100),
                        ContactTitle = c.String(),
                        Address = c.String(maxLength: 200),
                        Phone = c.Int(nullable: false),
                        Email = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        StateID = c.Int(nullable: false, identity: true),
                        StateName = c.String(nullable: false),
                        CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StateID)
                .ForeignKey("dbo.Countries", t => t.CountryID, cascadeDelete: true)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryID = c.Int(nullable: false, identity: true),
                        CountryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CountryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cities", "State_StateID", "dbo.States");
            DropForeignKey("dbo.States", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.Orders", "EmployeeID", "dbo.Employees");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Employees", "CityID", "dbo.Cities");
            DropForeignKey("dbo.Products", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.OrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryID", "dbo.Categories");
            DropIndex("dbo.States", new[] { "CountryID" });
            DropIndex("dbo.Orders", new[] { "EmployeeID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropIndex("dbo.Employees", new[] { "CityID" });
            DropIndex("dbo.Cities", new[] { "State_StateID" });
            DropIndex("dbo.OrderDetails", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "SupplierID" });
            DropIndex("dbo.Products", new[] { "CategoryID" });
            DropTable("dbo.Countries");
            DropTable("dbo.States");
            DropTable("dbo.Customers");
            DropTable("dbo.Orders");
            DropTable("dbo.Employees");
            DropTable("dbo.Cities");
            DropTable("dbo.Suppliers");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
