using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;


namespace Meeteam_Backend
{
    public class GroupRequirement
    {
        public string require_id { get; set; }
        public string release_time { get; set; }
        public string purpose { get; set; }
        public string team_type { get; set; }
        public string team_limit { get; set; }
        public string details { get; set; }
        public string require_status { get; set; }
        public string originator_id { get; set; }
        public string project_id { get; set; }
    }
}
