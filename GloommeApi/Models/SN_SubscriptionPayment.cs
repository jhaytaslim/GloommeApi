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
    
    public partial class SN_SubscriptionPayment
    {
        public int PaymentID { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<int> InvoiceID { get; set; }
        public Nullable<decimal> Amount { get; set; }
    }
}
