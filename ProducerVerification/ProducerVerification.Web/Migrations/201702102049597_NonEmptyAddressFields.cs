namespace ProducerVerification.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NonEmptyAddressFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProducerInfo", "MailingStreet", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.ProducerInfo", "MailingCity", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.ProducerInfo", "MailingState", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.ProducerInfo", "MailingZipCode", c => c.String(nullable: false, maxLength: 41));
            AlterColumn("dbo.ProducerInfo", "PhysicalStreet", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.ProducerInfo", "PhysicalCity", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.ProducerInfo", "PhysicalState", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.ProducerInfo", "PhysicalZipCode", c => c.String(nullable: false, maxLength: 41));
            AlterColumn("dbo.ProducerInfo", "BillingStreet", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.ProducerInfo", "BillingCity", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.ProducerInfo", "BillingState", c => c.String(nullable: false, maxLength: 4));
            AlterColumn("dbo.ProducerInfo", "BillingZipCode", c => c.String(nullable: false, maxLength: 41));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProducerInfo", "BillingZipCode", c => c.String(maxLength: 41));
            AlterColumn("dbo.ProducerInfo", "BillingState", c => c.String(maxLength: 4));
            AlterColumn("dbo.ProducerInfo", "BillingCity", c => c.String(maxLength: 30));
            AlterColumn("dbo.ProducerInfo", "BillingStreet", c => c.String(maxLength: 30));
            AlterColumn("dbo.ProducerInfo", "PhysicalZipCode", c => c.String(maxLength: 41));
            AlterColumn("dbo.ProducerInfo", "PhysicalState", c => c.String(maxLength: 4));
            AlterColumn("dbo.ProducerInfo", "PhysicalCity", c => c.String(maxLength: 30));
            AlterColumn("dbo.ProducerInfo", "PhysicalStreet", c => c.String(maxLength: 30));
            AlterColumn("dbo.ProducerInfo", "MailingZipCode", c => c.String(maxLength: 41));
            AlterColumn("dbo.ProducerInfo", "MailingState", c => c.String(maxLength: 4));
            AlterColumn("dbo.ProducerInfo", "MailingCity", c => c.String(maxLength: 30));
            AlterColumn("dbo.ProducerInfo", "MailingStreet", c => c.String(maxLength: 30));
        }
    }
}
