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
    
    public partial class SN_Settlement
    {
        public int SettlementID { get; set; }
        public Nullable<int> ProviderID { get; set; }
        public Nullable<decimal> ProviderAmount { get; set; }
        public Nullable<decimal> PaymentAmount { get; set; }
        public Nullable<decimal> Commission { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<int> CustomerID { get; set; }
    }
}
