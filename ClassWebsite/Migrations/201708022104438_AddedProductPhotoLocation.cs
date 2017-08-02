namespace ClassWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProductPhotoLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "PhotoLocation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "PhotoLocation");
        }
    }
}
