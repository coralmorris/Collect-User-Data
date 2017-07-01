namespace ProducerVerification.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreProducerFields : DbMigration
    {
        public override void Up()
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
            AddColumn("dbo.ProducerInfo", "PrimaryPhoneType", c => c.Int(nullable: false));
            AddColumn("dbo.ProducerInfo", "SecondaryPhoneType", c => c.Int(nullable: false));
            AlterColumn("dbo.ProducerInfo", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.ProducerInfo", "BusinessName", c => c.String(nullable: false));
            AlterColumn("dbo.ProducerInfo", "PrimaryPhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.ProducerInfo", "EmailAddress", c => c.String(nullable: false));
            CreateIndex("dbo.ProducerInfo", "MailingAddressId");
            AddForeignKey("dbo.ProducerInfo", "MailingAddressId", "dbo.Address", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProducerInfo", "MailingAddressId", "dbo.Address");
            DropIndex("dbo.ProducerInfo", new[] { "MailingAddressId" });
            AlterColumn("dbo.ProducerInfo", "EmailAddress", c => c.String());
            AlterColumn("dbo.ProducerInfo", "PrimaryPhoneNumber", c => c.String());
            AlterColumn("dbo.ProducerInfo", "BusinessName", c => c.String());
            AlterColumn("dbo.ProducerInfo", "Name", c => c.String());
            DropColumn("dbo.ProducerInfo", "SecondaryPhoneType");
            DropColumn("dbo.ProducerInfo", "PrimaryPhoneType");
            DropColumn("dbo.ProducerInfo", "MailingAddressId");
            DropTable("dbo.Address");
        }
    }
}
