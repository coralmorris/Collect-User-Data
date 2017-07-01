using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProducerVerification.Web.Models
{
    public class ProducerUserInfo
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecID { get; set; }

        [Required]
        [MaxLength(8)]
        [DisplayName("Producer Code")]
        public string ProducerCode { get; set; }

        [Required]
        [MaxLength(150)]
        [EmailAddress]
        [DisplayName("Email Address")]
        public string UserCode { get; set; }

        [NotMapped]
        //[MaxLength(150)]
        //[EmailAddress]
        //[Compare("UserCode", ErrorMessage = "The email and confirmation email do not match.")]
        [DisplayName("Confirm Email Address")]
        public string ConfirmUserCode { get; set; }

        [NotMapped]
        [DisplayName("Business Name")]
        public string BusinessName { get; set; }

        [NotMapped]
        [DisplayName("Authorization Code")]
        public string AuthorizationCode { get; set; }

        [MaxLength(30)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [MaxLength(30)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [MaxLength(50)]
        [DisplayName("Business Address")]
        public string Address1 { get; set; }

        [MaxLength(50)]
        [DisplayName("Business Address")]
        public string Address2 { get; set; }

        [MaxLength(50)]
        [DisplayName("City")]
        public string City { get; set; }

        [MaxLength(2)]
        [DisplayName("State")]
        public string State { get; set; }

        [MaxLength(5)]
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }

        public string PrimaryPhoneType { get; set; }

        [MaxLength(16)]
        [Phone]
        [DisplayName("Primary Phone")]
        public string PrimaryPhoneNumber { get; set; }

        public string SecondaryPhoneType { get; set; }

        [MaxLength(16)]
        [Phone]
        [DisplayName("Secondary Phone")]
        public string SecondaryPhoneNumber { get; set; }

        [MaxLength(16)]
        [Phone]
        [DisplayName("Fax Number")]
        public string FaxNumber { get; set; }

        public bool EmailVerified { get; set; }


    }
}