namespace ProducerVerification.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAuthCodeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthenticationCodes",
                c => new
                    {
                        ProducerCode = c.String(nullable: false, maxLength: 128),
                        AuthenticationCode = c.String(),
                    })
                .PrimaryKey(t => t.ProducerCode);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AuthenticationCodes");
        }
    }
}
