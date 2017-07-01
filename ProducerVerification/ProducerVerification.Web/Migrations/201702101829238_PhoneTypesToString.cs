namespace ProducerVerification.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneTypesToString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProducerInfo", "PrimaryPhoneType", c => c.String(nullable: false));
            AddColumn("dbo.ProducerInfo", "SecondaryPhoneType", c => c.String(nullable: false));
            DropColumn("dbo.ProducerInfo", "PrimaryPhoneTypeEnum");
            DropColumn("dbo.ProducerInfo", "SecondaryPhoneTypeEnum");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProducerInfo", "SecondaryPhoneTypeEnum", c => c.Int(nullable: false));
            AddColumn("dbo.ProducerInfo", "PrimaryPhoneTypeEnum", c => c.Int(nullable: false));
            DropColumn("dbo.ProducerInfo", "SecondaryPhoneType");
            DropColumn("dbo.ProducerInfo", "PrimaryPhoneType");
        }
    }
}
