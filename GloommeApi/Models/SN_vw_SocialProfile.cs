//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GloommeApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SN_vw_SocialProfile
    {
        public int SocialID { get; set; }
        public string EmailAddress { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public string SocialType { get; set; }
        public Nullable<bool> IsOnline { get; set; }
        public Nullable<System.DateTime> LastLoginDate { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public string ProfilePictureURL { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string CountryID { get; set; }
        public string State { get; set; }
        public string InstitutionName { get; set; }
        public string Course { get; set; }
        public string DegreeObtained { get; set; }
        public string CompanyName { get; set; }
        public Nullable<System.DateTime> YearEmployed { get; set; }
        public string Position { get; set; }
        public string City { get; set; }
    }
}
