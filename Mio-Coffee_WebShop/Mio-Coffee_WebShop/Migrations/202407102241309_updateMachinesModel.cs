namespace Mio_Coffee_WebShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMachinesModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Machines", "ImageURL", c => c.String());
            DropColumn("dbo.Machines", "Style");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Machines", "Style", c => c.String());
            DropColumn("dbo.Machines", "ImageURL");
        }
    }
}
