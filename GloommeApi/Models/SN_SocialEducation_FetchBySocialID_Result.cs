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
    
    public partial class SN_SocialEducation_FetchBySocialID_Result
    {
        public int SocialEducationID { get; set; }
        public string InstitutionName { get; set; }
        public Nullable<int> YearFrom { get; set; }
        public Nullable<int> YearTo { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public string Course { get; set; }
        public string DegreeObtained { get; set; }
        public string EmailAddress { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
    }
}