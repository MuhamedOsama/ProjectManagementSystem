using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.Models
{
    public class ProjectManager : User
    {
        public List<Project> Projects { get; set; }
    }
}