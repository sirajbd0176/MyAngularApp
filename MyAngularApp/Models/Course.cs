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
        public int DepartmentId { get; set; }
        //[ForeignKey("DepID")]
        //public Department id { get; set; }
        public Department Department { get; set; }
        
    }
}