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
    
    public partial class SN_Proposals
    {
        public int ProposalID { get; set; }
        public int CustomerPostID { get; set; }
        public int ProviderID { get; set; }
        public Nullable<int> ProposedTimeLine { get; set; }
        public Nullable<decimal> ProposedAmount { get; set; }
        public string Remark { get; set; }
        public Nullable<System.DateTime> DateaCreated { get; set; }
        public Nullable<bool> IsAccepted { get; set; }
        public Nullable<System.DateTime> DateAccepted { get; set; }
    }
}
