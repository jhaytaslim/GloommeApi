using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GloommeApi.Models
{
    public class SN_MessagesInfo
    {
        [Required]
        public int JobID { get; set; }
        public int ProviderID { get; set; }
        public int CustomerID { get; set; }
        public int SourceID { get; set; }
        public bool IsReade { get; set; }
        public string Message { get; set; }
       
    }
}