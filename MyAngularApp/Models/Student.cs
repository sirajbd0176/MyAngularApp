using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyAngularApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public string Session { get; set; }
   public  Department Department { get; set; }   
   //public List<Department> Depts { get; set; }
    }
}