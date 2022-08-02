using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace Meeteam_Backend
{
    public class Notice
    {
        public string notice_title { get; set; }
        public string notice_content { get; set; }
    }
}