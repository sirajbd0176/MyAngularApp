﻿using System;
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
    public class DepartmentController : ApiController
    {
        private MyContext db = new MyContext();

        // GET api/Department
        public IEnumerable<Department> GetDepartments()
        {
            return db.Depatsments.AsEnumerable();
        }

        // GET api/Department/5
        public Department GetDepartment(int id)
        {
            Department department = db.Depatsments.Find(id);
            if (department == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return department;
        }

        // PUT api/Department/5
        public HttpResponseMessage PutDepartment(int id, Department department)
        {
            if (ModelState.IsValid && id == department.Id)
            {
                db.Entry(department).State = EntityState.Modified;

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

        // POST api/Department
        public HttpResponseMessage PostDepartment(Department department)
        {
            if (ModelState.IsValid)
            {
                db.Depatsments.Add(department);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, department);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = department.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/Department/5
        public HttpResponseMessage DeleteDepartment(int id)
        {
            Department department = db.Depatsments.Find(id);
            if (department == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Depatsments.Remove(department);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, department);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}