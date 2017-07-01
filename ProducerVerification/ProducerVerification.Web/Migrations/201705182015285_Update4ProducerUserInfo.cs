namespace ProducerVerification.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update4ProducerUserInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProducerUserInfo", "ConfirmUserCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProducerUserInfo", "ConfirmUserCode");
        }
    }
}
