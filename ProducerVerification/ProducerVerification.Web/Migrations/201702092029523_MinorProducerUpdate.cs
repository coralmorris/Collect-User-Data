namespace ProducerVerification.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MinorProducerUpdate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProducerInfo", "SeparateAccountEntityName", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProducerInfo", "SeparateAccountEntityName", c => c.String());
        }
    }
}
