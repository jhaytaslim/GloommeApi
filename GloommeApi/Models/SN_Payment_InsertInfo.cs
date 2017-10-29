using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace GloommeApi.Models
{
    public class SN_Payment_InsertInfo
    {
            #region " Properties "
            [Required]
            public int CustomerID { get; set; }
           
            [Required]
            public int InvoiceID { get; set; }

            [Required]
            public int JobID { get; set; }

            [Required]
            public string PaymentDescription { get; set; }

            [Required]
            public string Amount { get; set; }

          
            #endregion
        
    }
}