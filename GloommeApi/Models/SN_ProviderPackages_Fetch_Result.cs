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
    
    public partial class SN_ProviderPackages_Fetch_Result
    {
        public int ProviderPackageID { get; set; }
        public Nullable<int> ProviderID { get; set; }
        public Nullable<int> AreaID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string PackageName { get; set; }
        public string PackageDescription { get; set; }
        public string Timeline { get; set; }
        public string TimelineType { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> AccountTypeID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string MiddleName { get; set; }
        public string CompanyName { get; set; }
    }
}
