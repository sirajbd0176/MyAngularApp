using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MyAngularApp.Models;
using System.Web.Http.Cors;

namespace MyAngularApp.Controllers
{    
    public class StudentController : ApiController
    {
        private MyContext db = new MyContext();

        // GET api/Student
        public IEnumerable<Student> GetStudents()
        {
            return db.Students.AsEnumerable();
        }

        // GET api/Student/5
        public Student GetStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return student;
        }


        //////////////////department//////////////////////

        //public IEnumerable<Student> GetDepartment()
        //{
        //    return db.Depatsments.AsEnumerable();
        //}

        //// GET api/Student/5
        //public Student GetDepartment(int id)
        //{
        //    Student student = db.Students.Find(id);
        //    if (student == null)
        //    {
        //        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        //    }

        //    return Department;
        //}






        ////////////////////////////////////

        // PUT api/Student/5
        public HttpResponseMessage PutStudent(int id, Student student)
        {
            if (ModelState.IsValid && id == student.Id)
            {
                db.Entry(student).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/Student
        public HttpResponseMessage PostStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, student);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = student.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Student/5
        public HttpResponseMessage DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Students.Remove(student);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, student);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}