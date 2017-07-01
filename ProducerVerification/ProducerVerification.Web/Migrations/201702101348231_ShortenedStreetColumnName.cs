namespace ProducerVerification.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShortenedStreetColumnName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProducerInfo", "MailingStreet", c => c.String(maxLength: 30));
            AddColumn("dbo.ProducerInfo", "PhysicalStreet", c => c.String(maxLength: 30));
            AddColumn("dbo.ProducerInfo", "BillingStreet", c => c.String(maxLength: 30));
            DropColumn("dbo.ProducerInfo", "MailingStreetNameHouseNumber");
            DropColumn("dbo.ProducerInfo", "PhysicalStreetNameHouseNumber");
            DropColumn("dbo.ProducerInfo", "BillingStreetNameHouseNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProducerInfo", "BillingStreetNameHouseNumber", c => c.String(maxLength: 30));
            AddColumn("dbo.ProducerInfo", "PhysicalStreetNameHouseNumber", c => c.String(maxLength: 30));
            AddColumn("dbo.ProducerInfo", "MailingStreetNameHouseNumber", c => c.String(maxLength: 30));
            DropColumn("dbo.ProducerInfo", "BillingStreet");
            DropColumn("dbo.ProducerInfo", "PhysicalStreet");
            DropColumn("dbo.ProducerInfo", "MailingStreet");
        }
    }
}
