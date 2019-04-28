using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        
        public string UserId { get; set; }
        public User User { get; set; }
    }
}