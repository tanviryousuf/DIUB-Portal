using DIUBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DIUBAPI.Controllers
{
    [RoutePrefix("api/Subjects")]
    public class SubjectController : ApiController
    {
        DIUBDatabaseEntities context = new DIUBDatabaseEntities();
        [Route("")]
        public IHttpActionResult Get()
        {
            var list = context.Tbl_SubjectDetails.ToList();
            List<Tbl_SubjectDetails> categories = new List<Tbl_SubjectDetails>();
            foreach (var item in list)
            {
                Tbl_SubjectDetails cat = new Tbl_SubjectDetails();
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
        [Route("{id}", Name = "GetSubjectById")]
        public IHttpActionResult Get(int id)
        {
            var item = context.Tbl_SubjectDetails.Where(p => p.SubjectID == id).FirstOrDefault();
            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                Tbl_SubjectDetails cat = new Tbl_SubjectDetails();
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
        [Route("{id}")]
        public IHttpActionResult Post([FromUri]int id,[FromBody]Tbl_SubjectDetails subject)
        {
            var item = context.Tbl_PreSubjectDetails.Where(x => x.SubjectID == id).FirstOrDefault();
            subject.SubjectID = item.SubjectID;
            subject.SubjectName = item.SubjectName;
            subject.Credit = item.Credit;
            subject.DepartmentID = item.DepartmentID;
            subject.IsLabExist = item.IsLabExist;
            context.Tbl_SubjectDetails.Add(subject);
            context.Tbl_PreSubjectDetails.Remove(item);
            context.SaveChanges();
            return Created(Url.Link("GetSubjectById", new { id = subject.SubjectID }), subject);
        }
        [Route("{id}")]
        public IHttpActionResult Put([FromUri]int id, [FromBody]Tbl_SubjectDetails subject)
        {
            var item = context.Tbl_SubjectDetails.Where(p => p.SubjectID == id).FirstOrDefault();
            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                item.SubjectID = subject.SubjectID;
                item.SubjectName = subject.SubjectName;
                item.Credit = subject.Credit;
                item.DepartmentID = subject.DepartmentID;
                item.IsLabExist = subject.IsLabExist;
                return Ok(item);
            }

        }

        [Route("{id}")]
        public IHttpActionResult Delete([FromUri]int id)
        {
            var item = context.Tbl_SubjectDetails.Where(p => p.SubjectID == id).FirstOrDefault();
            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                context.Tbl_SubjectDetails.Remove(item);
                context.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }

        }

        [Route("{id}/PreSections")]
        public IHttpActionResult GetPreSectionBySubject([FromUri]int id)
        {
            var list = context.Tbl_PreSectionDistribution.Where(p => p.SubjectID == id);
            if (list.FirstOrDefault() == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                List<Tbl_PreSectionDistribution> comments = new List<Tbl_PreSectionDistribution>();
                foreach (var item in list)
                {
                    Tbl_PreSectionDistribution pro = new Tbl_PreSectionDistribution();
                    pro.SectionID = item.SectionID;
                    pro.SectionName = item.SectionName;
                    pro.Capacity = item.Capacity;
                    pro.SubjectID = id;
                    pro.Day1 = item.Day1;
                    pro.ClassStart = item.ClassStart;
                    pro.ClassEnd = item.ClassEnd;
                    pro.Day2 = item.Day2;
                    pro.ClassStart2 = item.ClassStart2;
                    pro.ClassEnd2 = item.ClassEnd2;
                    pro.SemesterID = item.SemesterID;
                    pro.DepartmentID = item.DepartmentID;
                    pro.Available = item.Available;
                    pro.Credit = item.Credit;
                    pro.IsConfirmed = item.IsConfirmed;
                    pro.Status = item.Status;
                    pro.TeacherID = item.TeacherID;
                    comments.Add(pro);
                }
                return Ok(comments);
            }
        }
        
        [Route("{id}/PreSections/{id1}", Name = "GetPreSectionBySubjectID")]
     public IHttpActionResult GetPreSectionBySubjectID([FromUri]int id,int id1)
     {
         var list = context.Tbl_PreSectionDistribution.Where(p => p.SubjectID == id && p.SectionID == id1);
         if (list.FirstOrDefault() == null)
         {
             return StatusCode(HttpStatusCode.NoContent);
         }
         else
         {
             List<Tbl_PreSectionDistribution> comments = new List<Tbl_PreSectionDistribution>();
             foreach (var item in list)
             {
                    Tbl_PreSectionDistribution pro = new Tbl_PreSectionDistribution();
                    pro.SectionID = item.SectionID;
                    pro.SectionName = item.SectionName;
                    pro.Capacity = item.Capacity;
                    pro.SubjectID = id;
                    pro.Day1 = item.Day1;
                    pro.ClassStart = item.ClassStart;
                    pro.ClassEnd = item.ClassEnd;
                    pro.Day2 = item.Day2;
                    pro.ClassStart2 = item.ClassStart2;
                    pro.ClassEnd2 = item.ClassEnd2;
                    pro.SemesterID = item.SemesterID;
                    pro.DepartmentID = item.DepartmentID;
                    pro.Available = item.Available;
                    pro.Credit = item.Credit;
                    pro.IsConfirmed = item.IsConfirmed;
                    pro.Status = item.Status;
                    pro.TeacherID = item.TeacherID;
                    comments.Add(pro);
             }
             return Ok(comments);
         }

     }
     [Route("{id}/PreSections")]
     public IHttpActionResult PostPreSection([FromBody]Tbl_PreSectionDistribution pro, [FromUri]int id)
     {

            try
            {
                pro.SubjectID = id;
                context.Tbl_PreSectionDistribution.Add(pro);
                context.SaveChanges();
                return Created(Url.Link("GetPreSectionBySubjectID", new { id = pro.SubjectID, id1 = pro.SubjectID }), pro);
            }
            catch(Exception ex)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
           
     }
     [Route("{id}/PreSections/{id1}")]
     public IHttpActionResult PutPreSection([FromUri]int id,[FromUri]int id1, [FromBody]Tbl_PreSectionDistribution item)
     {
         var pro = context.Tbl_PreSectionDistribution.Where(p => p.SubjectID == id && p.SectionID == id1).FirstOrDefault();
         if (pro == null)
         {
             return StatusCode(HttpStatusCode.NoContent);
         }
         else
         {
                pro.SectionID = id1;
                pro.SectionName = item.SectionName;
                pro.Capacity = item.Capacity;
                pro.SubjectID = id;
                pro.Day1 = item.Day1;
                pro.ClassStart = item.ClassStart;
                pro.ClassEnd = item.ClassEnd;
                pro.Day2 = item.Day2;
                pro.ClassStart2 = item.ClassStart2;
                pro.ClassEnd2 = item.ClassEnd2;
                pro.SemesterID = item.SemesterID;
                pro.DepartmentID = item.DepartmentID;
                pro.Available = item.Available;
                pro.Credit = item.Credit;
                pro.IsConfirmed = item.IsConfirmed;
                pro.Status = item.Status;
                pro.TeacherID = item.TeacherID;
                context.SaveChanges();
                item.Tbl_SubjectDetails = new Tbl_SubjectDetails();
             return Ok(item);
         }

     }

     [Route("{id}/PreSections/{id1}")]
     public IHttpActionResult DeleteComment([FromUri]int id, [FromUri]int id1)
     {
         var item = context.Tbl_PreSectionDistribution.Where(p => p.SectionID == id1 && p.SubjectID == id).FirstOrDefault();
         if (item == null)
         {
             return StatusCode(HttpStatusCode.NoContent);
         }
         else
         {
             context.Tbl_PreSectionDistribution.Remove(item);
             context.SaveChanges();
             return StatusCode(HttpStatusCode.NoContent);
         }

     }   
    }
}
