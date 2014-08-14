namespace Accounting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOwnerCompany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cities", "State_StateID", "dbo.States");
            DropIndex("dbo.Cities", new[] { "State_StateID" });
            CreateTable(
                "dbo.OwnerCompanies",
                c => new
                    {
                        OwnerID = c.Guid(nullable: false),
                        Owner = c.String(nullable: false),
                        About = c.String(),
                        Cotact = c.String(),
                    })
                .PrimaryKey(t => t.OwnerID);
            
            AddColumn("dbo.Categories", "OwnerID", c => c.Guid());
            AddColumn("dbo.Products", "OwnerID", c => c.Guid());
            AddColumn("dbo.Suppliers", "OwnerID", c => c.Guid());
            AddColumn("dbo.Cities", "SateID", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "OwnerCompany_OwnerID", c => c.Guid());
            AddColumn("dbo.Customers", "OwnerID", c => c.Guid());
            AlterColumn("dbo.Cities", "State_StateID", c => c.Int());
            CreateIndex("dbo.Categories", "OwnerID");
            CreateIndex("dbo.Customers", "OwnerID");
            CreateIndex("dbo.Employees", "OwnerCompany_OwnerID");
            CreateIndex("dbo.Cities", "State_StateID");
            CreateIndex("dbo.Products", "OwnerID");
            CreateIndex("dbo.Suppliers", "OwnerID");
            AddForeignKey("dbo.Categories", "OwnerID", "dbo.OwnerCompanies", "OwnerID");
            AddForeignKey("dbo.Employees", "OwnerCompany_OwnerID", "dbo.OwnerCompanies", "OwnerID");
            AddForeignKey("dbo.Customers", "OwnerID", "dbo.OwnerCompanies", "OwnerID");
            AddForeignKey("dbo.Products", "OwnerID", "dbo.OwnerCompanies", "OwnerID");
            AddForeignKey("dbo.Suppliers", "OwnerID", "dbo.OwnerCompanies", "OwnerID");
            AddForeignKey("dbo.Cities", "State_StateID", "dbo.States", "StateID");
            DropColumn("dbo.Cities", "SatteID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cities", "SatteID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Cities", "State_StateID", "dbo.States");
            DropForeignKey("dbo.Suppliers", "OwnerID", "dbo.OwnerCompanies");
            DropForeignKey("dbo.Products", "OwnerID", "dbo.OwnerCompanies");
            DropForeignKey("dbo.Customers", "OwnerID", "dbo.OwnerCompanies");
            DropForeignKey("dbo.Employees", "OwnerCompany_OwnerID", "dbo.OwnerCompanies");
            DropForeignKey("dbo.Categories", "OwnerID", "dbo.OwnerCompanies");
            DropIndex("dbo.Suppliers", new[] { "OwnerID" });
            DropIndex("dbo.Products", new[] { "OwnerID" });
            DropIndex("dbo.Cities", new[] { "State_StateID" });
            DropIndex("dbo.Employees", new[] { "OwnerCompany_OwnerID" });
            DropIndex("dbo.Customers", new[] { "OwnerID" });
            DropIndex("dbo.Categories", new[] { "OwnerID" });
            AlterColumn("dbo.Cities", "State_StateID", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "OwnerID");
            DropColumn("dbo.Employees", "OwnerCompany_OwnerID");
            DropColumn("dbo.Cities", "SateID");
            DropColumn("dbo.Suppliers", "OwnerID");
            DropColumn("dbo.Products", "OwnerID");
            DropColumn("dbo.Categories", "OwnerID");
            DropTable("dbo.OwnerCompanies");
            CreateIndex("dbo.Cities", "State_StateID");
            AddForeignKey("dbo.Cities", "State_StateID", "dbo.States", "StateID", cascadeDelete: true);
        }
    }
}
