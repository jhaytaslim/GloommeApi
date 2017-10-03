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
    
    public partial class SN_vw_Jobs
    {
        public int JobID { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> ProviderID { get; set; }
        public Nullable<int> PackageID { get; set; }
        public string Comment { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<int> InvoiceID { get; set; }
        public Nullable<bool> IsAccepted { get; set; }
        public Nullable<System.DateTime> DateAccepted { get; set; }
        public string ProviderComment { get; set; }
        public Nullable<bool> IsComplete { get; set; }
        public Nullable<bool> IsCustomerComplete { get; set; }
        public Nullable<System.DateTime> DateCustomerComplete { get; set; }
        public string ProviderName { get; set; }
        public string CustomerName { get; set; }
        public string PackageName { get; set; }
        public string PackageDescription { get; set; }
        public Nullable<int> AreaID { get; set; }
        public Nullable<int> CategoryID { get; set; }
    }
}
