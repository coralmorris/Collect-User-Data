namespace ProducerVerification.Web.Migrations
{
    using DAL;
    using Models;
    using Models.Enums;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProducerVerification.Web.DAL.ProducerVerificationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProducerVerificationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //context.Producers.AddOrUpdate(p => p.AgencyName, new ProducerInfo()
            //{
            //    AgencyName = "Test Producer",
            //    BusinessName = "Test Producer",
            //    EmailAddress = "email@address.com",
            //    PrimaryPhoneNumber = "123",
            //    PrimaryPhoneType = PhoneType.Business,
            //    PreferredPaymentMethod = CommissionPaymentMethod.ACH
            //});

        }
    }
}
