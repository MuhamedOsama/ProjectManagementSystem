using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementSystem.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileContentType { get; set; }
        public string FilePath { get; set; }
    }
}