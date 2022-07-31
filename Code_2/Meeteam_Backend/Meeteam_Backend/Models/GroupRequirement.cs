using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;


namespace MeeTeam_Back
{
    public class GroupRequirement
    {
        public String require_id { get; set; }
        public DateTime release_time { get; set; }
        public String purpose { get; set; }
        public String team_type { get; set; }
        public String team_limit { get; set; }
        public String details { get; set; }
        public String require_status { get; set; }
        public String originator_id { get; set; }
        public String project_id { get; set; }
    }
}
