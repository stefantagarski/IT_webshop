namespace Mio_Coffee_WebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class identitymodels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coffees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Rating = c.Int(nullable: false),
                        Type = c.String(),
                        Origin = c.String(),
                        Composition = c.String(),
                        Price = c.Int(nullable: false),
                        Product_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.Product_ID)
                .Index(t => t.Product_ID);
            
            CreateTable(
                "dbo.Machines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Brand = c.String(),
                        Usage = c.String(),
                        Style = c.String(),
                        Price = c.Int(nullable: false),
                        Product_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.Product_ID)
                .Index(t => t.Product_ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        coffeeID = c.Int(nullable: false),
                        machineID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Coffees", "Product_ID", "dbo.Products");
            DropForeignKey("dbo.Machines", "Product_ID", "dbo.Products");
            DropIndex("dbo.Machines", new[] { "Product_ID" });
            DropIndex("dbo.Coffees", new[] { "Product_ID" });
            DropTable("dbo.Products");
            DropTable("dbo.Machines");
            DropTable("dbo.Coffees");
        }
    }
}
