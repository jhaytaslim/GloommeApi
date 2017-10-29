
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace GloommeApi.Models
{
    public class MsgDictionary
    {
        //public string Description { get; set; }

        public List<DataTable> MsgObject { get; set; }


    }

    public class MsgTables
    {
        public string Description { get; set; }

        public DataTable Tables { get; set; }


    }
}