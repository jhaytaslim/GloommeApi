using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GloommeApi.Models
{
    public class SN_Proposal_Insert
    {
        [Required]
        public int CustomerPostID { get; set; }
        public int ProviderID { get; set; }
        public Nullable<int> ProposedTimeLine { get; set; }
        public Nullable<decimal> ProposedAmount { get; set; }
        public string Remark { get; set; }
        
    }
}
