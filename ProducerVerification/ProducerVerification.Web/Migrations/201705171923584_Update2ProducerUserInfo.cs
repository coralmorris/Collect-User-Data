namespace ProducerVerification.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update2ProducerUserInfo : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProducerUserInfo", "FirstName", c => c.String(maxLength: 30));
            AlterColumn("dbo.ProducerUserInfo", "LastName", c => c.String(maxLength: 30));
            AlterColumn("dbo.ProducerUserInfo", "Address1", c => c.String(maxLength: 50));
            AlterColumn("dbo.ProducerUserInfo", "Address2", c => c.String(maxLength: 50));
            AlterColumn("dbo.ProducerUserInfo", "City", c => c.String(maxLength: 50));
            AlterColumn("dbo.ProducerUserInfo", "State", c => c.String(maxLength: 2));
            AlterColumn("dbo.ProducerUserInfo", "ZipCode", c => c.String(maxLength: 5));
            AlterColumn("dbo.ProducerUserInfo", "PrimaryPhoneType", c => c.String());
            AlterColumn("dbo.ProducerUserInfo", "PrimaryPhoneNumber", c => c.String(maxLength: 16));
            AlterColumn("dbo.ProducerUserInfo", "SecondaryPhoneType", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProducerUserInfo", "SecondaryPhoneType", c => c.String(nullable: false));
            AlterColumn("dbo.ProducerUserInfo", "PrimaryPhoneNumber", c => c.String(nullable: false, maxLength: 16));
            AlterColumn("dbo.ProducerUserInfo", "PrimaryPhoneType", c => c.String(nullable: false));
            AlterColumn("dbo.ProducerUserInfo", "ZipCode", c => c.String(nullable: false, maxLength: 5));
            AlterColumn("dbo.ProducerUserInfo", "State", c => c.String(nullable: false, maxLength: 2));
            AlterColumn("dbo.ProducerUserInfo", "City", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ProducerUserInfo", "Address2", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ProducerUserInfo", "Address1", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.ProducerUserInfo", "LastName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.ProducerUserInfo", "FirstName", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
