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
    
    public partial class SN_SocialPosts
    {
        public int SocialPostID { get; set; }
        public Nullable<int> SocialID { get; set; }
        public Nullable<System.DateTime> DatePosted { get; set; }
        public string ContentType { get; set; }
        public string Message { get; set; }
        public string MessageFileURL { get; set; }
    }
}
