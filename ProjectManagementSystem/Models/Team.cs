using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.Models
{
    public class Team
    {
        public int Id { get; set; }
        public List<Developer> Developers { get; set; }
        public ProjectManager ProjectManager { get; set; }
        public TeamLeader TeamLeader { get; set; }
        public Project Project { get; set; }
    }
}