using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.Models
{
    public class Team
    {
        public int TeamId;
        public List<Developer> Developers;
        public ProjectManager ProjectManager;
        public TeamLeader TeamLeader;
    }
}