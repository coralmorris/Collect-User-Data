namespace ProducerVerification.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetupForPaymentMethodEnumToString : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProducerInfo", "PreferredPaymentMethodString", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProducerInfo", "PreferredPaymentMethodString");
        }
    }
}
