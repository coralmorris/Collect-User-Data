namespace ProducerVerification.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ConsolidatedAddresses : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProducerInfo", "MailingAddressId", "dbo.Address");
            DropIndex("dbo.ProducerInfo", new[] { "MailingAddressId" });
            AddColumn("dbo.ProducerInfo", "ProducerCode", c => c.String(nullable: false, maxLength: 8));
            AddColumn("dbo.ProducerInfo", "AgencyName", c => c.String(nullable: false));
            AddColumn("dbo.ProducerInfo", "MailingStreetNameHouseNumber", c => c.String(maxLength: 30));
            AddColumn("dbo.ProducerInfo", "MailingCity", c => c.String(maxLength: 30));
            AddColumn("dbo.ProducerInfo", "MailingState", c => c.String(maxLength: 4));
            AddColumn("dbo.ProducerInfo", "MailingZipCode", c => c.String(maxLength: 41));
            AddColumn("dbo.ProducerInfo", "PhysicalStreetNameHouseNumber", c => c.String(maxLength: 30));
            AddColumn("dbo.ProducerInfo", "PhysicalCity", c => c.String(maxLength: 30));
            AddColumn("dbo.ProducerInfo", "PhysicalState", c => c.String(maxLength: 4));
            AddColumn("dbo.ProducerInfo", "PhysicalZipCode", c => c.String(maxLength: 41));
            AddColumn("dbo.ProducerInfo", "BillingStreetNameHouseNumber", c => c.String(maxLength: 30));
            AddColumn("dbo.ProducerInfo", "BillingCity", c => c.String(maxLength: 30));
            AddColumn("dbo.ProducerInfo", "BillingState", c => c.String(maxLength: 4));
            AddColumn("dbo.ProducerInfo", "BillingZipCode", c => c.String(maxLength: 41));
            AddColumn("dbo.ProducerInfo", "BankName", c => c.String(nullable: false));
            AddColumn("dbo.ProducerInfo", "RoutingNumber", c => c.String(nullable: false));
            AddColumn("dbo.ProducerInfo", "LastFourAccountNumber", c => c.String(nullable: false));
            AddColumn("dbo.ProducerInfo", "ExpirationYear", c => c.Int(nullable: false));
            AlterColumn("dbo.ProducerInfo", "DoingBusinessAs", c => c.String(maxLength: 30));
            DropColumn("dbo.ProducerInfo", "Name");
            DropColumn("dbo.ProducerInfo", "MailingAddressId");
            DropTable("dbo.Address");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StreetNameHouseNumber = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ProducerInfo", "MailingAddressId", c => c.Int(nullable: false));
            AddColumn("dbo.ProducerInfo", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ProducerInfo", "DoingBusinessAs", c => c.String());
            DropColumn("dbo.ProducerInfo", "ExpirationYear");
            DropColumn("dbo.ProducerInfo", "LastFourAccountNumber");
            DropColumn("dbo.ProducerInfo", "RoutingNumber");
            DropColumn("dbo.ProducerInfo", "BankName");
            DropColumn("dbo.ProducerInfo", "BillingZipCode");
            DropColumn("dbo.ProducerInfo", "BillingState");
            DropColumn("dbo.ProducerInfo", "BillingCity");
            DropColumn("dbo.ProducerInfo", "BillingStreetNameHouseNumber");
            DropColumn("dbo.ProducerInfo", "PhysicalZipCode");
            DropColumn("dbo.ProducerInfo", "PhysicalState");
            DropColumn("dbo.ProducerInfo", "PhysicalCity");
            DropColumn("dbo.ProducerInfo", "PhysicalStreetNameHouseNumber");
            DropColumn("dbo.ProducerInfo", "MailingZipCode");
            DropColumn("dbo.ProducerInfo", "MailingState");
            DropColumn("dbo.ProducerInfo", "MailingCity");
            DropColumn("dbo.ProducerInfo", "MailingStreetNameHouseNumber");
            DropColumn("dbo.ProducerInfo", "AgencyName");
            DropColumn("dbo.ProducerInfo", "ProducerCode");
            CreateIndex("dbo.ProducerInfo", "MailingAddressId");
            AddForeignKey("dbo.ProducerInfo", "MailingAddressId", "dbo.Address", "Id", cascadeDelete: true);
        }
    }
}
