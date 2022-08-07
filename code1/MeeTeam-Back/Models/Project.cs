using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SqlSugar;

namespace Meeteam_Backend
{
    [SugarTable("Project")]
    public class Project
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string project_id { get; set; }

        [SugarColumn(IsJson = true)]
        public string project_name { get; set; }
        public string project_background { get; set; }
        public string project_info { get; set; }
        public string project_content { get; set; }
        public string project_status { get; set; }
        public string project_stime { get; set; }
        public string project_etime { get; set; }
        public string project_progress { get; set; }
        public string admin_id { get; set; }
        public char audit_result { get; set; }
        public string audit_time { get; set; }

    }
}
