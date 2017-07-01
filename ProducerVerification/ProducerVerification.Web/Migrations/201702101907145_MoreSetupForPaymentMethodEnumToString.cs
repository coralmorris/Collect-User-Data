namespace ProducerVerification.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreSetupForPaymentMethodEnumToString : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProducerInfo", "PreferredPaymentMethod");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProducerInfo", "PreferredPaymentMethod", c => c.Int(nullable: false));
        }
    }
}
