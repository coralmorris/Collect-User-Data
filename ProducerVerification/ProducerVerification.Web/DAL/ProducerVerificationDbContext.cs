using ProducerVerification.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProducerVerification.Web.DAL
{
    public class ProducerVerificationDbContext : DbContext
    {
        public ProducerVerificationDbContext() : base("ProducerVerificationDbContext") { }


        //Tables
        public DbSet<ProducerInfo> Producers { get; set; }
        public DbSet<AuthenticationCodes> AuthenticationCodes { get; set; }
        //public DbSet<Address> Addresses { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
        }

        public System.Data.Entity.DbSet<ProducerVerification.Web.Models.ProducerUserInfo> ProducerUserInfoes { get; set; }
    }
}