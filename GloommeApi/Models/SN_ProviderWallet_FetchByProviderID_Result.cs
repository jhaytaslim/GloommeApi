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
    
    public partial class SN_ProviderWallet_FetchByProviderID_Result
    {
        public int ProviderWalletID { get; set; }
        public Nullable<int> JobID { get; set; }
        public Nullable<int> ProviderID { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string PaymentType { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    }
}
