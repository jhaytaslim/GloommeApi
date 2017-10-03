using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GloommeApi.Models
{
    public class Customer
    {
        //public int CustomerID { get; set; }
        [Required]
        public string Firstname{ get; set; }
        [Required]
        public string Lastname{ get; set; }
        [Required]
        public string Middlename{ get; set; }
        [Required]
        public DateTime DateOfBirth{ get; set; }
        [Required]
        public string Gender{ get; set; }
        [Required]
        public string Email{ get; set; }
        [Required]
        public string PhoneNo{ get; set; }
        [Required]
        public string CustomerAddress{ get; set; }
        [Required]
        public string City{ get; set; }
        [Required]
        public string State{ get; set; }
        [Required]
        public int CountryID{ get; set; }
        [Required]
        public string Password{ get; set; }
        //[Required]
        //public DateTime DateCreated{ get; set; }
        //[Required]
        //public string IPAddress{ get; set; }
        //[Required]
        //public string Longitude{ get; set; }
        //[Required]
        //public string Latitude{ get; set; }
        //[Required]
        //public DateTime LastLoginDate{ get; set; }
        //[Required]
        //public bool CustomerActive { get; set; }
    }
}