using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GloommeApi.Models
{
    public class ProviderVM
    {
        public int ProviderID { get; set; }
        public int ProviderTypeID { get; set; }
        public int AccountTypeID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string MiddleName { get; set; }
        public string CompanyName { get; set; }
        public string ProviderAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int CountryID { get; set; }
        public string EmailAddress { get; set; }
        public string ProviderPassword { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IPAddress { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public int CategoryID { get; set; }

        public string ProfilePictureURL { get; set; }
    }

    public class ProviderCertification
    {

        ///public int ProviderCertificationID { get; set; }
        [Required]
        public int ProviderID { get; set; }

        [Required]
        public string CertificationName { get; set; }

        [Required]
        public string YearAchived { get; set; }

        [Required]
        public string CertificationProvider { get; set; }
    }

    public class ProviderPackages
    {
        //public int ProviderPackageID { get; set; }

        [Required]
        public int ProviderID { get; set; }

        [Required]
        public int AreaID { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        public string PackageName { get; set; }

        [Required]
        public string PackageDescription { get; set; }

        [Required]
        public string Timeline { get; set; }

        [Required]
        public string TimelineType { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public bool IsActive { get; set; }

    }

    public class ProviderBank
    {
        [Required]
        public int ProviderID { get; set; }

        [Required]
        public int BankID { get; set; }

        [Required]
        public string AccountNo { get; set; }

        [Required]
        public string SortCode { get; set; }

        [Required]
        public string AccountName { get; set; }
    }

    public class ProviderKeyWords
    {
        [Required]
        public int ProviderID { get; set; }

        [Required]
        public string KeyWord { get; set; }
    }
}