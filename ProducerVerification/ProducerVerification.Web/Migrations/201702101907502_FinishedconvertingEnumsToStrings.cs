namespace ProducerVerification.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinishedconvertingEnumsToStrings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProducerInfo", "PreferredPaymentMethod", c => c.String(nullable: false));
            DropColumn("dbo.ProducerInfo", "PreferredPaymentMethodString");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProducerInfo", "PreferredPaymentMethodString", c => c.String(nullable: false));
            DropColumn("dbo.ProducerInfo", "PreferredPaymentMethod");
        }
    }
}
