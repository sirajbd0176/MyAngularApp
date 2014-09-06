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

namespace MyAngularApp.Controllers
{
    public class FacultyController : ApiController
    {
        private MyContext db = new MyContext();

        // GET api/fFaculty
        public IEnumerable<Faculty> GetFaculties()
        {
            return db.Faculties.AsEnumerable();
        }

        // GET api/fFaculty/5
        public Faculty GetFaculty(int id)
        {
            Faculty faculty = db.Faculties.Find(id);
            if (faculty == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return faculty;
        }

        // PUT api/fFaculty/5
        public HttpResponseMessage PutFaculty(int id, Faculty faculty)
        {
            if (ModelState.IsValid && id == faculty.Id)
            {
                db.Entry(faculty).State = EntityState.Modified;

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

        // POST api/fFaculty
        public HttpResponseMessage PostFaculty(Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                db.Faculties.Add(faculty);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, faculty);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = faculty.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/fFaculty/5
        public HttpResponseMessage DeleteFaculty(int id)
        {
            Faculty faculty = db.Faculties.Find(id);
            if (faculty == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Faculties.Remove(faculty);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, faculty);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}