using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Data.SqlClient;
using SqlSugar;


namespace Meeteam_Backend.Models
{
    [SugarTable("project")]
    public class Project
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string project_id { get; set; }

        [SugarColumn(IsJson = true)]
        public string project_name { get; set; }
        public string project_background { get; set; }
        public string project_introduction { get; set; }
        public string project_content { get; set; }
        public string project_status { get; set; }
        public string create_time { get; set; }
        public string due { get; set; }
        public string project_progress { get; set; }
        public string admin_id { get; set; }
        public char audit_result { get; set; }
        public string audit_time { get; set; }

    }
}
