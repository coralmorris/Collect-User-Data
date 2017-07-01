namespace ProducerVerification.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1ProducerUserInfo : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProducerUserInfo", "ConfirmUserCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProducerUserInfo", "ConfirmUserCode", c => c.String(nullable: false, maxLength: 150));
        }
    }
}
