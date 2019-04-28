using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.Models
{
    public class ProjectsHistory
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public User User { get; set; }
        public byte Status { get; set; }
    }
}