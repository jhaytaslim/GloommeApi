using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GloommeApi.Models
{
    public class SN_ProviderAreasInfo
    {

        #region " Properties "
        public int ProviderAreaID { get; set; }

        [Required]
        public int ProviderID { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        public int AreaID { get; set; }

        public DateTime DateCreated { get; set; }

        #endregion

    }

}