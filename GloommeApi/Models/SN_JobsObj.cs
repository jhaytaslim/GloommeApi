using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace GloommeApi.Models
{
    public class SN_JobsReject
    {
        #region " Properties "
        [Required]
        public int JobID { get; set; }

        [Required]
        public string ProviderComment { get; set; }

        #endregion
    }

    public class SN_JobsCustomerComlpeted
    {
        #region " Properties "
        [Required]
        public int JobID { get; set; }

        [Required]
        public int RatingScore { get; set; }

        #endregion
    }
}