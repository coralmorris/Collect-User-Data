namespace ProducerVerification.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneTypeRename : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProducerInfo", "PrimaryPhoneTypeEnum", c => c.Int(nullable: false));
            AddColumn("dbo.ProducerInfo", "SecondaryPhoneTypeEnum", c => c.Int(nullable: false));
            DropColumn("dbo.ProducerInfo", "PrimaryPhoneType");
            DropColumn("dbo.ProducerInfo", "SecondaryPhoneType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProducerInfo", "SecondaryPhoneType", c => c.Int(nullable: false));
            AddColumn("dbo.ProducerInfo", "PrimaryPhoneType", c => c.Int(nullable: false));
            DropColumn("dbo.ProducerInfo", "SecondaryPhoneTypeEnum");
            DropColumn("dbo.ProducerInfo", "PrimaryPhoneTypeEnum");
        }
    }
}
