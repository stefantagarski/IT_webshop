namespace Mio_Coffee_WebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCoffeeModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coffees", "ImageURL", c => c.String());
            AlterColumn("dbo.Coffees", "Rating", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Coffees", "Rating", c => c.Int(nullable: false));
            DropColumn("dbo.Coffees", "ImageURL");
        }
    }
}
