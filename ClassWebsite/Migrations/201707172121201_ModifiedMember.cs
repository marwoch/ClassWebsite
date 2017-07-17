namespace ClassWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedMember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Members", "SecurityAnswer", c => c.String());
            AlterColumn("dbo.Members", "UserName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Members", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "Email", c => c.String());
            AlterColumn("dbo.Members", "Password", c => c.String());
            AlterColumn("dbo.Members", "UserName", c => c.String());
            DropColumn("dbo.Members", "SecurityAnswer");
        }
    }
}
