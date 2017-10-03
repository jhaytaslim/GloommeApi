using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GloommeApi.Models
{
    #region "SN_Skills Object Class "

    public class SN_SkillsInfo
    {
        #region " Properties "
        public int SkillID { get; set; }

        [Required]
        public int ProviderID { get; set; }

        public int AreaID { get; set; }

        [Required]
        public string SkillName { get; set; }

        [Required]
        public string SkillDescription { get; set; }

        public DateTime DateCreated { get; set; }

        #endregion

    }

    #endregion

}