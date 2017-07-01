namespace ProducerVerification.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitWithProducerInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProducerInfo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BusinessName = c.String(),
                        DoingBusinessAs = c.String(),
                        PrimaryPhoneNumber = c.String(),
                        SecondaryPhoneNumber = c.String(),
                        EmailAddress = c.String(),
                        Fax = c.String(),
                        SeparateAccountEntityName = c.String(),
                        PreferredPaymentMethod = c.Int(nullable: false),
                        IpAddress = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProducerInfo");
        }
    }
}
