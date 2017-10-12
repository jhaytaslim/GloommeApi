using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GloommeApi.Models
{
    public class SN_JobsInfo
    {
        #region " Properties "
        [Required]
        public int CustomerID { get; set; }
        //public string CustomerD;
        //public void set(string are)
        //{
        //    CustomerD = are;
        //}

        //public int get()
        //{
        //    return CustomerID;
        //}
        [Required]
        public int ProviderID { get; set; }

        [Required]
        public int PackageID { get; set; }

        [Required]
        public string Comment { get; set; }

        [Required]
        public string Amount { get; set; }

        public static explicit operator List<object>(SN_JobsInfo v)
        {
            throw new NotImplementedException();
        }

        //public DateTime DateCreated { get; set; }

        #endregion
    }

    public class SN_ApproveJob
    {
        [Required]
        public int JobID { get; set; }

        [Required]
        public bool IsAccepted { get; set; }

        [Required]
        public string Comment { get; set; }

        public decimal Amount { get; set; }

    }
}