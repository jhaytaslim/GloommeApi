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
    
    public partial class SN_Subscription_Fetch_Result
    {
        public int SubscriptionID { get; set; }
        public int ProviderID { get; set; }
        public int AccountTypeID { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<int> IsComplete { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<int> PaymentID { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string MiddleName { get; set; }
        public string CompanyName { get; set; }
    }
}