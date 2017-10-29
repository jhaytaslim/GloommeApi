using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GloommeApi.Models
{
    public class SN_CustomerJobs_Insert
    {
        //public int CustomerPostID { get; set; }
        [Required]
        public  int CustomerID { get; set; }
        [Required]
        public string PostMessage { get; set; }
        [Required]
        public  int TimeLineInHours { get; set; }
        [Required]
        public  decimal FeeFrom { get; set; }
        [Required]
        public  decimal FeeTo { get; set; }
        [Required]
        public  bool IsActive { get; set; }
    }
}