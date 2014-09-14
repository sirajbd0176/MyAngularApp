using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyAngularApp.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Course> Courses { get; set; }
        // this is for one to (many student dep one 
        public List<Student> Students { get; set; }

      
        //public virtual Student student { get; set; }
    }
}