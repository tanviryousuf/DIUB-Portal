using DIUBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DIUBAPI.Controllers
{
    [RoutePrefix("api/PreEmployees")]
    public class PreEmployeeController : ApiController
    {
        DIUBDatabaseEntities context = new DIUBDatabaseEntities();
        [Route("")]
        public IHttpActionResult Get()
        {
            var list = context.Tbl_PreEmployee.ToList();
            List<Tbl_PreEmployee> categories = new List<Tbl_PreEmployee>();
            foreach (var item in list)
            {
                Tbl_PreEmployee cat = new Tbl_PreEmployee();
                cat.ID = item.ID;
                cat.EmployeeID = item.EmployeeID;
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
                
                cat.Password = item.Password;
                cat.Picture = item.Picture;
                cat.Type = item.Type;
                cat.Status = item.Status;

                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts", Method = "GET", Rel = "Self" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + cat.EmployeeID, Method = "GET", Rel = "Specific Resource" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + cat.EmployeeID, Method = "PUT", Rel = "Resource Edit" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + cat.EmployeeID, Method = "DELETE", Rel = "Resource Delete" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts", Method = "POST", Rel = "Resource Create" });

                categories.Add(cat);
            }
            return Ok(categories);
        }
        [Route("{id}", Name = "GetPreEmployeeById")]
        public IHttpActionResult Get(string id)
        {
            var item = context.Tbl_PreEmployee.Where(p => p.EmployeeID == id).FirstOrDefault();
            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                Tbl_PreEmployee cat = new Tbl_PreEmployee();
                cat.ID = item.ID;
                cat.EmployeeID = item.EmployeeID;
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
                
                cat.Password = item.Password;
                cat.Picture = item.Picture;
                cat.Type = item.Type;
                cat.Status = item.Status;

                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts", Method = "GET", Rel = "Self" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + cat.EmployeeID, Method = "GET", Rel = "Specific Resource" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + cat.EmployeeID, Method = "PUT", Rel = "Resource Edit" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + cat.EmployeeID, Method = "DELETE", Rel = "Resource Delete" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts", Method = "POST", Rel = "Resource Create" });

                return Ok(cat);
            }

        }
        [Route("")]
        public IHttpActionResult Post([FromBody]Tbl_PreEmployee preEmployee)
        {

            context.Tbl_PreEmployee.Add(preEmployee);
            context.SaveChanges();
            return Created(Url.Link("GetPreEmployeeById", new { id = preEmployee.EmployeeID }), preEmployee);
        }
        [Route("{id}")]
        public IHttpActionResult Put([FromUri]string id, [FromBody]Tbl_PreEmployee item)
        {
            var cat = context.Tbl_PreEmployee.Where(p => p.EmployeeID == id).FirstOrDefault();
            if (cat == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {

                cat.ID = item.ID;
                cat.EmployeeID = item.EmployeeID;
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
            var item = context.Tbl_PreEmployee.Where(p => p.EmployeeID == id).FirstOrDefault();
            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                context.Tbl_PreEmployee.Remove(item);
                context.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }

        }
    }
}
