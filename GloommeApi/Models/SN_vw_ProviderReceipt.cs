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
    
    public partial class SN_vw_ProviderReceipt
    {
        public int ProviderReceiptID { get; set; }
        public Nullable<int> JobID { get; set; }
        public Nullable<System.DateTime> DateReceived { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<int> PackageID { get; set; }
        public Nullable<int> CustomerID { get; set; }
    }
}
