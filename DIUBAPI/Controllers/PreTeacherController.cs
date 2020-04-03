using DIUBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DIUBAPI.Controllers
{
    [RoutePrefix("api/PreTeachers")]
    public class PreTeacherController : ApiController
    {
        DIUBDatabaseEntities context = new DIUBDatabaseEntities();
        [Route("")]
        public IHttpActionResult Get()
        {
            var list = context.Tbl_PreTeacher.ToList();
            List<Tbl_PreTeacher> categories = new List<Tbl_PreTeacher>();
            foreach (var item in list)
            {
                Tbl_PreTeacher cat = new Tbl_PreTeacher();
                cat.ID = item.ID;
                cat.TeacherID = item.TeacherID;
                cat.FirstName = item.FirstName;
                cat.LastName = item.LastName;
                cat.BirthDate = item.BirthDate;
                cat.DepartmentID = item.DepartmentID;
               
                cat.PresentAddress = item.PresentAddress;
                cat.PermanentAddress = item.PermanentAddress;
                cat.Phone = item.Phone;
                cat.Email = item.Email;
                cat.Sex = item.Sex;
                cat.Nationality = item.Nationality;
                cat.Religion = item.Religion;
                cat.MaritalStatus = item.MaritalStatus;
                cat.BloodGroup = item.BloodGroup;
                
                cat.JoiningDate = item.JoiningDate;
                cat.SalaryCategoryID = item.SalaryCategoryID;
                cat.DocumentsGiven = item.DocumentsGiven;
                cat.Password = item.Password;
                cat.Picture = item.Picture;
                cat.Type = item.Type;
                cat.Status = item.Status;

                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts", Method = "GET", Rel = "Self" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + cat.TeacherID, Method = "GET", Rel = "Specific Resource" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + cat.TeacherID, Method = "PUT", Rel = "Resource Edit" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + cat.TeacherID, Method = "DELETE", Rel = "Resource Delete" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts", Method = "POST", Rel = "Resource Create" });

                categories.Add(cat);
            }
            return Ok(categories);
        }
        [Route("{id}", Name = "GetPreTeacherById")]
        public IHttpActionResult Get(string id)
        {
            var item = context.Tbl_PreTeacher.Where(p => p.TeacherID == id).FirstOrDefault();
            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                Tbl_PreTeacher cat = new Tbl_PreTeacher();
                cat.ID = item.ID;
                cat.TeacherID = item.TeacherID;
                cat.FirstName = item.FirstName;
                cat.LastName = item.LastName;
                cat.BirthDate = item.BirthDate;
                cat.DepartmentID = item.DepartmentID;

                cat.PresentAddress = item.PresentAddress;
                cat.PermanentAddress = item.PermanentAddress;
                cat.Phone = item.Phone;
                cat.Email = item.Email;
                cat.Sex = item.Sex;
                cat.Nationality = item.Nationality;
                cat.Religion = item.Religion;
                cat.MaritalStatus = item.MaritalStatus;
                cat.BloodGroup = item.BloodGroup;

                cat.JoiningDate = item.JoiningDate;
                cat.SalaryCategoryID = item.SalaryCategoryID;
                cat.DocumentsGiven = item.DocumentsGiven;
                cat.Password = item.Password;
                cat.Picture = item.Picture;
                cat.Type = item.Type;
                cat.Status = item.Status;

                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts", Method = "GET", Rel = "Self" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + cat.TeacherID, Method = "GET", Rel = "Specific Resource" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + cat.TeacherID, Method = "PUT", Rel = "Resource Edit" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + cat.TeacherID, Method = "DELETE", Rel = "Resource Delete" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts", Method = "POST", Rel = "Resource Create" });
                return Ok(cat);
            }

        }
        [Route("")]
        public IHttpActionResult Post([FromBody]Tbl_PreTeacher preTeacher)
        {

            context.Tbl_PreTeacher.Add(preTeacher);
            context.SaveChanges();
            return Created(Url.Link("GetPreTeacherById", new { id = preTeacher.TeacherID }), preTeacher);
        }
        [Route("{id}")]
        public IHttpActionResult Put([FromUri]string id, [FromBody]Tbl_PreTeacher item)
        {
            var cat = context.Tbl_PreTeacher.Where(p => p.TeacherID == id).FirstOrDefault();
            if (cat == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                
                cat.ID = item.ID;
                cat.TeacherID = item.TeacherID;
                cat.FirstName = item.FirstName;
                cat.LastName = item.LastName;
                cat.BirthDate = item.BirthDate;
                cat.DepartmentID = item.DepartmentID;

                cat.PresentAddress = item.PresentAddress;
                cat.PermanentAddress = item.PermanentAddress;
                cat.Phone = item.Phone;
                cat.Email = item.Email;
                cat.Sex = item.Sex;
                cat.Nationality = item.Nationality;
                cat.Religion = item.Religion;
                cat.MaritalStatus = item.MaritalStatus;
                cat.BloodGroup = item.BloodGroup;

                cat.JoiningDate = item.JoiningDate;
                cat.SalaryCategoryID = item.SalaryCategoryID;
                cat.DocumentsGiven = item.DocumentsGiven;
                cat.Password = item.Password;
                cat.Picture = item.Picture;
                cat.Type = item.Type;
                cat.Status = item.Status;
                return Ok(item);
            }

        }

        [Route("{id}")]
        public IHttpActionResult Delete([FromUri]string id)
        {
            var item = context.Tbl_PreTeacher.Where(p => p.TeacherID == id).FirstOrDefault();
            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                context.Tbl_PreTeacher.Remove(item);
                context.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }

        }
    }
}
