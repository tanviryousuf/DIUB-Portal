using DIUBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DIUBAPI.Controllers
{
    [RoutePrefix("api/PreSubjects")]
    public class PreSubjectController : ApiController
    {
        DIUBDatabaseEntities context = new DIUBDatabaseEntities();
        [Route("")]
        public IHttpActionResult Get()
        {
            var list = context.Tbl_PreSubjectDetails.ToList();
            List<Tbl_PreSubjectDetails> categories = new List<Tbl_PreSubjectDetails>();
            foreach (var item in list)
            {
                Tbl_PreSubjectDetails cat = new Tbl_PreSubjectDetails();
                cat.SubjectID = item.SubjectID;
                cat.SubjectName = item.SubjectName;
                cat.Credit = item.Credit;
                cat.DepartmentID = item.DepartmentID;
                cat.IsLabExist = item.IsLabExist;
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts", Method = "GET", Rel = "Self" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + cat.SubjectID, Method = "GET", Rel = "Specific Resource" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + cat.SubjectID, Method = "PUT", Rel = "Resource Edit" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + cat.SubjectID, Method = "DELETE", Rel = "Resource Delete" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts", Method = "POST", Rel = "Resource Create" });

                categories.Add(cat);
            }
            return Ok(categories);
        }
        [Route("{id}", Name = "GetPreSubjectById")]
        public IHttpActionResult Get(int id)
        {
            var item = context.Tbl_PreSubjectDetails.Where(p => p.SubjectID == id).FirstOrDefault();
            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                Tbl_PreSubjectDetails cat = new Tbl_PreSubjectDetails();
                cat.SubjectID = item.SubjectID;
                cat.SubjectName = item.SubjectName;
                cat.Credit = item.Credit;
                cat.DepartmentID = item.DepartmentID;
                cat.IsLabExist = item.IsLabExist;
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts", Method = "GET", Rel = "Self" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + cat.SubjectID, Method = "GET", Rel = "Specific Resource" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + cat.SubjectID, Method = "PUT", Rel = "Resource Edit" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + cat.SubjectID, Method = "DELETE", Rel = "Resource Delete" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts", Method = "POST", Rel = "Resource Create" });

                return Ok(cat);
            }

        }
        [Route("")]
        public IHttpActionResult Post([FromBody]Tbl_PreSubjectDetails preSubjectDetails)
        {

            context.Tbl_PreSubjectDetails.Add(preSubjectDetails);
            context.SaveChanges();
            return Created(Url.Link("GetPreSubjectById", new { id = preSubjectDetails.SubjectID }), preSubjectDetails);
        }
        [Route("{id}")]
        public IHttpActionResult Put([FromUri]int id, [FromBody]Tbl_PreSubjectDetails post)
        {
            var cat = context.Tbl_PreSubjectDetails.Where(p => p.SubjectID == id).FirstOrDefault();
            if (cat == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                cat.SubjectID = id;
                cat.SubjectName = post.SubjectName;
                cat.Credit = post.Credit;
                cat.DepartmentID = post.DepartmentID;
                cat.IsLabExist = post.IsLabExist;
                context.SaveChanges();
                return Ok(cat);
            }

        }

        [Route("{id}")]
        public IHttpActionResult Delete([FromUri]int id)
        {
            var item = context.Tbl_PreSubjectDetails.Where(p => p.SubjectID == id).FirstOrDefault();
            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                context.Tbl_PreSubjectDetails.Remove(item);
                context.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }

        }

        
    }
}
