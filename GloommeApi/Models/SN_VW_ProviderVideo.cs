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
    
    public partial class SN_VW_ProviderVideo
    {
        public int ProviderVideoID { get; set; }
        public Nullable<int> ProviderID { get; set; }
        public string VideoDescription { get; set; }
        public string VideoURL { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<int> AccountTypeID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string MiddleName { get; set; }
        public string CompanyName { get; set; }
    }
}
