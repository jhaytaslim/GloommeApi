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
    
    public partial class SN_Invoices
    {
        public int InvoiceID { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDescription { get; set; }
        public Nullable<int> JobID { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<decimal> Amount { get; set; }
    }
}