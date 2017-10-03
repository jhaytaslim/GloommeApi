using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GloommeApi.Models
{
    public class CategoryVM
    {


        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public DateTime DateCreated { get; set; }

        public int CreatedBy { get; set; }

        public bool IsActive { get; set; }

        public string CategoryImageURL { get; set; }
    }

    #region "SN_ProviderCategory Object Class "

    public class SN_ProviderCategoryVM
    {

        #region " Properties "
        public int ProviderCategoryID { get; set; }

        [Required]
        public int ProviderID { get; set; }

        [Required]
        public int CategoryID { get; set; }

        public DateTime DateCreated { get; set; }

        #endregion

    }

    #endregion
}