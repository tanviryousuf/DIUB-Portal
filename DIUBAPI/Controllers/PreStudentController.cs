using DIUBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DIUBAPI.Controllers
{
    [RoutePrefix("api/PreStudents")]
    public class PreStudentController : ApiController
    {
        DIUBDatabaseEntities context = new DIUBDatabaseEntities();
        [Route("")]
        public IHttpActionResult Get()
        {
            var list = context.Tbl_PreStudent.ToList();
            List<Tbl_PreStudent> categories = new List<Tbl_PreStudent>();
            foreach (var item in list)
            {
                Tbl_PreStudent cat = new Tbl_PreStudent();
                cat.ConfrimID = item.ConfrimID;
                cat.StudentID = item.StudentID;
                cat.FirstName = item.FirstName;
                cat.LastName = item.LastName;
                cat.BirthDate = item.BirthDate;
                cat.DepartmentID = item.DepartmentID;
                cat.FatherName = item.FatherName;
                cat.MotherName = item.MotherName;
                cat.PresentAddress = item.PresentAddress;
                cat.PermanentAddress = item.PermanentAddress;
                cat.Phone = item.Phone;
                cat.Email = item.Email;
                cat.Sex = item.Sex;
                cat.Nationality = item.Nationality;
                cat.Religion = item.Religion;
                cat.MaritalStatus = item.MaritalStatus;
                cat.BloodGroup = item.BloodGroup;
                cat.AdmissionDate = item.AdmissionDate;
                cat.GraduationDate = item.GraduationDate;
                cat.PerSemesterRecordID = item.PerSemesterRecordID;
                cat.DocumentsGiven = item.DocumentsGiven;
                cat.Password = item.Password;
                cat.Picture = item.Picture;
                cat.Type = item.Type;

                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts", Method = "GET", Rel = "Self" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + cat.StudentID, Method = "GET", Rel = "Specific Resource" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + cat.StudentID, Method = "PUT", Rel = "Resource Edit" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + cat.StudentID, Method = "DELETE", Rel = "Resource Delete" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts", Method = "POST", Rel = "Resource Create" });

                categories.Add(cat);
            }
            return Ok(categories);
        }
        [Route("{id}", Name = "GetPreStudentById")]
        public IHttpActionResult Get(string id)
        {
            var item = context.Tbl_PreStudent.Where(p => p.StudentID == id).FirstOrDefault();
            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                Tbl_PreStudent cat = new Tbl_PreStudent();
                cat.ConfrimID = item.ConfrimID;
                cat.StudentID = item.StudentID;
                cat.FirstName = item.FirstName;
                cat.LastName = item.LastName;
                cat.BirthDate = item.BirthDate;
                cat.DepartmentID = item.DepartmentID;
                cat.FatherName = item.FatherName;
                cat.MotherName = item.MotherName;
                cat.PresentAddress = item.PresentAddress;
                cat.PermanentAddress = item.PermanentAddress;
                cat.Phone = item.Phone;
                cat.Email = item.Email;
                cat.Sex = item.Sex;
                cat.Nationality = item.Nationality;
                cat.Religion = item.Religion;
                cat.MaritalStatus = item.MaritalStatus;
                cat.BloodGroup = item.BloodGroup;
                cat.AdmissionDate = item.AdmissionDate;
                cat.GraduationDate = item.GraduationDate;
                cat.PerSemesterRecordID = item.PerSemesterRecordID;
                cat.DocumentsGiven = item.DocumentsGiven;
                cat.Password = item.Password;
                cat.Picture = item.Picture;
                cat.Type = item.Type;

                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts", Method = "GET", Rel = "Self" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + cat.StudentID, Method = "GET", Rel = "Specific Resource" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + cat.StudentID, Method = "PUT", Rel = "Resource Edit" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + cat.StudentID, Method = "DELETE", Rel = "Resource Delete" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts", Method = "POST", Rel = "Resource Create" });
                return Ok(cat);
            }

        }
        [Route("")]
        public IHttpActionResult Post([FromBody]Tbl_PreStudent preStudent)
        {

            context.Tbl_PreStudent.Add(preStudent);
            context.SaveChanges();
            return Created(Url.Link("GetPreStudentById", new { id = preStudent.StudentID }), preStudent);
        }
        [Route("{id}")]
        public IHttpActionResult Put([FromUri]string id, [FromBody]Tbl_PreStudent item)
        {
            var cat = context.Tbl_PreStudent.Where(p => p.StudentID == id).FirstOrDefault();
            if (cat == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                cat.ConfrimID = item.ConfrimID;
                cat.StudentID = item.StudentID;
                cat.FirstName = item.FirstName;
                cat.LastName = item.LastName;
                cat.BirthDate = item.BirthDate;
                cat.DepartmentID = item.DepartmentID;
                cat.FatherName = item.FatherName;
                cat.MotherName = item.MotherName;
                cat.PresentAddress = item.PresentAddress;
                cat.PermanentAddress = item.PermanentAddress;
                cat.Phone = item.Phone;
                cat.Email = item.Email;
                cat.Sex = item.Sex;
                cat.Nationality = item.Nationality;
                cat.Religion = item.Religion;
                cat.MaritalStatus = item.MaritalStatus;
                cat.BloodGroup = item.BloodGroup;
                cat.AdmissionDate = item.AdmissionDate;
                cat.GraduationDate = item.GraduationDate;
                cat.PerSemesterRecordID = item.PerSemesterRecordID;
                cat.DocumentsGiven = item.DocumentsGiven;
                cat.Password = item.Password;
                cat.Picture = item.Picture;
                cat.Type = item.Type;
                return Ok(item);
            }

        }

        [Route("{id}")]
        public IHttpActionResult Delete([FromUri]string id)
        {
            var item = context.Tbl_PreStudent.Where(p => p.StudentID == id).FirstOrDefault();
            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                context.Tbl_PreStudent.Remove(item);
                context.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }

        }
    }
}
