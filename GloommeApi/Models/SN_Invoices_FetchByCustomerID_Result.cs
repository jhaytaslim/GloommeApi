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
    
    public partial class SN_Invoices_FetchByCustomerID_Result
    {
        public int InvoiceID { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDescription { get; set; }
        public Nullable<int> JobID { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Comment { get; set; }
    }
}
