namespace ClassWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMember : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        DateOfBirth = c.DateTime(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        SecurityQuestion = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.MemberID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Members");
        }
    }
}
