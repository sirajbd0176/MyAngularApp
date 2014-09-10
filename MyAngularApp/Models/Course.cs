using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyAngularApp.Models
{
    public class Course
    {

        public int Id { get; set; }
        public string CourseName { get; set; }
        public int DepID { get; set; }
        [ForeignKey("DepID")]
        public Department id { get; set; }
        
    }
}