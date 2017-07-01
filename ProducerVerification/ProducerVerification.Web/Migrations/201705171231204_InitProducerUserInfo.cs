namespace ProducerVerification.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitProducerUserInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProducerUserInfo",
                c => new
                    {
                        RecID = c.Int(nullable: false, identity: true),
                        ProducerCode = c.String(nullable: false, maxLength: 8),
                        UserCode = c.String(nullable: false, maxLength: 150),
                        ConfirmUserCode = c.String(nullable: false, maxLength: 150),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Address1 = c.String(nullable: false, maxLength: 50),
                        Address2 = c.String(nullable: false, maxLength: 50),
                        City = c.String(nullable: false, maxLength: 50),
                        State = c.String(nullable: false, maxLength: 2),
                        ZipCode = c.String(nullable: false, maxLength: 5),
                        PrimaryPhoneType = c.String(nullable: false),
                        PrimaryPhoneNumber = c.String(nullable: false, maxLength: 16),
                        SecondaryPhoneType = c.String(nullable: false),
                        SecondaryPhoneNumber = c.String(maxLength: 16),
                        FaxNumber = c.String(maxLength: 16),
                        EmailVerified = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.RecID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProducerUserInfo");
        }
    }
}
