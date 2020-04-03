using DIUBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DIUBAPI.Controllers
{
    [RoutePrefix("api/Teachers")]
    public class TeacherController : ApiController
    {
        DIUBDatabaseEntities context = new DIUBDatabaseEntities();
        [Route("")]
        public IHttpActionResult Get()
        {
            var list = context.Tbl_Teacher1.ToList();
            List<Tbl_Teacher1> categories = new List<Tbl_Teacher1>();
            foreach (var item in list)
            {
                Tbl_Teacher1 cat = new Tbl_Teacher1();
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

                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Teachers", Method = "GET", Rel = "Self" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Teachers/" + cat.TeacherID, Method = "GET", Rel = "Specific Resource" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Teachers/" + cat.TeacherID, Method = "PUT", Rel = "Resource Edit" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Teachers/" + cat.TeacherID, Method = "DELETE", Rel = "Resource Delete" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Teachers", Method = "POST", Rel = "Resource Create" });
                categories.Add(cat);
            }
            return Ok(categories);
        }
        [Route("{id}", Name = "GetTeacherById")]
        public IHttpActionResult Get(string id)
        {
            var item = context.Tbl_Teacher1.Where(p => p.TeacherID == id).FirstOrDefault();
            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                Tbl_Teacher1 cat = new Tbl_Teacher1();
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

                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Teachers", Method = "GET", Rel = "Self" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Teachers/" + cat.TeacherID, Method = "GET", Rel = "Specific Resource" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Teachers/" + cat.TeacherID, Method = "PUT", Rel = "Resource Edit" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Teachers/" + cat.TeacherID, Method = "DELETE", Rel = "Resource Delete" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Teachers", Method = "POST", Rel = "Resource Create" });
                return Ok(cat);
            }

        }
        [Route("")]
        public IHttpActionResult Post([FromBody]Tbl_PreTeacher pre)
        {
            var item = context.Tbl_PreTeacher.Where(x => x.TeacherID == pre.TeacherID).FirstOrDefault();

            Tbl_Teacher1 cat = new Tbl_Teacher1();
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
            Tbl_Accounts1 ac = new Tbl_Accounts1();

            ac.UserID = pre.TeacherID;
            ac.Password = item.Password;
            ac.Type = item.Type;

            context.Tbl_Teacher1.Add(cat);
            context.Tbl_Accounts1.Add(ac);
            context.Tbl_PreTeacher.Remove(item);
            context.SaveChanges();
            return Created(Url.Link("GetTeacherById", new { id = cat.TeacherID }), cat);
        }
        [Route("{id}")]
        public IHttpActionResult Put([FromUri]string id, [FromBody]Tbl_Teacher1 item)
        {
            var cat = context.Tbl_Teacher1.Where(p => p.TeacherID == id).FirstOrDefault();
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
            var item = context.Tbl_Teacher1.Where(p => p.TeacherID == id).FirstOrDefault();
            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                context.Tbl_Teacher1.Remove(item);
                context.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }
        }
            [Route("{id}/ClassRoutine")]
        public IHttpActionResult GetClassRoutineOfTeacher([FromUri]String id)
        {
            var list = context.Tbl_SectionDistribution.Where(p => p.TeacherID == id);
            if (list.FirstOrDefault() == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                List<Tbl_SectionDistribution> comments = new List<Tbl_SectionDistribution>();
                foreach (var item in list)
                {
                    Tbl_SectionDistribution pro = new Tbl_SectionDistribution();
                    pro.SectionID = item.SectionID;
                    pro.SectionName = item.SectionName;
                    pro.Capacity = item.Capacity;
                    pro.SubjectID = item.SubjectID;
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
                    pro.TeacherID = id;
                    pro.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + id + "/Comments", Method = "GET", Rel = "Self" });
                    pro.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + id + "/Comments/" + pro.TeacherID, Method = "GET", Rel = "Specific Resource" });
                    pro.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + id + "/Comments/" + pro.TeacherID, Method = "PUT", Rel = "Resource Edit" });
                    pro.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + id + "/Comments/" + pro.TeacherID, Method = "DELETE", Rel = "Resource Delete" });
                    pro.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + id + "/Comments", Method = "POST", Rel = "Resource Create" });
                    comments.Add(pro);
                }
                return Ok(comments);
            }
        }

        [Route("{id}/MarksOfStudents", Name = "GetMarksByTeacher")]
        public IHttpActionResult GetMarksOfStudents([FromUri]String id)
        {
            var list = context.Tbl_MidResult.Where(p => p.TeacherID == id).OrderBy(x=>x.SectionID);
            if (list.FirstOrDefault() == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                List<Tbl_MidResult> comments = new List<Tbl_MidResult>();
                foreach (var item in list)
                {
                    Tbl_MidResult pro = new Tbl_MidResult();
                    pro.ResultID = item.ResultID;
                    pro.TeacherID = item.TeacherID;
                    pro.StudentID = item.StudentID;
                    pro.SectionID = item.SectionID;
                    pro.SubjectID = item.SubjectID;
                    pro.LabPerformanceMid = item.LabPerformanceMid;
                    pro.PerformanceMid = item.PerformanceMid;
                    pro.MidFinal = item.MidFinal;
                    pro.TotalMarksMid = item.TotalMarksMid;
                    pro.GradeMid = item.GradeMid;
                    pro.AttendanceFinal = item.AttendanceFinal;
                    pro.QuizFinal = item.QuizFinal;
                    pro.PerformanceFinal = item.PerformanceFinal;
                    pro.LabPerformanceFinal = item.LabPerformanceFinal;
                    pro.Quiz1 = item.Quiz1;
                    pro.Quiz2 = item.Quiz2;
                    pro.Quiz3 = item.Quiz3;
                    pro.Quiz4 = item.Quiz4;
                    pro.Quiz5 = item.Quiz5;
                    pro.Quiz6 = item.Quiz6;
                    pro.FinalFinal = item.FinalFinal;
                    pro.TotalMarksFinal = item.TotalMarksFinal;
                    pro.GradeFinal = item.GradeFinal;
                    pro.TotalMarks = item.TotalMarks;
                    pro.Grade = item.Grade;
                    
                    pro.LabFinal = item.LabFinal;



                    pro.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + id + "/Comments", Method = "GET", Rel = "Self" });
                    pro.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + id + "/Comments/" + pro.TeacherID, Method = "GET", Rel = "Specific Resource" });
                    pro.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + id + "/Comments/" + pro.TeacherID, Method = "PUT", Rel = "Resource Edit" });
                    pro.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + id + "/Comments/" + pro.TeacherID, Method = "DELETE", Rel = "Resource Delete" });
                    pro.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + id + "/Comments", Method = "POST", Rel = "Resource Create" });
                    comments.Add(pro);
                }
                return Ok(comments);
            }
        }

     
        [Route("{id}/MarksUpload")]
        public IHttpActionResult PostMarks([FromBody]Tbl_MidResult pro, [FromUri]string id)
        {


            pro.TeacherID = id;
            context.Tbl_MidResult.Add(pro);
            context.SaveChanges();
            return Created(Url.Link("GetMarksByTeacher", new { id = pro.TeacherID }), pro);
        }
        [Route("{id}/MarksUpload/{id1}")]
        public IHttpActionResult PutMarks([FromUri]string id, [FromUri]int id1, [FromBody]Tbl_MidResult item)
        {
            var pro = context.Tbl_MidResult.Where(p => p.TeacherID == id && p.ResultID == id1).FirstOrDefault();
            if (pro == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                pro.ResultID = id1;
                pro.TeacherID = id;
                pro.StudentID = item.StudentID;
                pro.SectionID = item.SectionID;
                pro.SubjectID = item.SubjectID;
                pro.LabPerformanceMid = item.LabPerformanceMid;
                pro.PerformanceMid = item.PerformanceMid;
                pro.MidFinal = item.MidFinal;
                pro.TotalMarksMid = item.TotalMarksMid;
                pro.GradeMid = item.GradeMid;
                pro.AttendanceFinal = item.AttendanceFinal;
                pro.QuizFinal = item.QuizFinal;
                pro.PerformanceFinal = item.PerformanceFinal;
                pro.LabPerformanceFinal = item.LabPerformanceFinal;
                pro.Quiz1 = item.Quiz1;
                pro.Quiz2 = item.Quiz2;
                pro.Quiz3 = item.Quiz3;
                pro.Quiz4 = item.Quiz4;
                pro.Quiz5 = item.Quiz5;
                pro.Quiz6 = item.Quiz6;
                pro.FinalFinal = item.FinalFinal;
                pro.TotalMarksFinal = item.TotalMarksFinal;
                pro.GradeFinal = item.GradeFinal;
                pro.TotalMarks = item.TotalMarks;
                pro.Grade = item.Grade;

                pro.LabFinal = item.LabFinal; 
               
               
                context.SaveChanges();
                item.Tbl_Teacher1 = new Tbl_Teacher1();
                return Ok(item);
            }

        }
        [Route("{id}/Notes")]
        public IHttpActionResult GetNotesByTeacher([FromUri]string id)
        {
            var list = context.Tbl_Notes.Where(p => p.TeacherID == id);
            if (list.FirstOrDefault() == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                List<Tbl_Notes> comments = new List<Tbl_Notes>();
                foreach (var item in list)
                {
                    Tbl_Notes pro = new Tbl_Notes();
                    pro.NotesID = item.NotesID;
                    pro.TeacherID = item.TeacherID;
                    pro.Note = item.Note;
                    pro.SubjectID = item.SubjectID;
                    pro.SectionID = item.SectionID;
                    pro.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + id + "/Comments", Method = "GET", Rel = "Self" });
                    pro.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + id + "/Comments/" + pro.NotesID, Method = "GET", Rel = "Specific Resource" });
                    pro.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + id + "/Comments/" + pro.NotesID, Method = "PUT", Rel = "Resource Edit" });
                    pro.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + id + "/Comments/" + pro.NotesID, Method = "DELETE", Rel = "Resource Delete" });
                    pro.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + id + "/Comments", Method = "POST", Rel = "Resource Create" });
                    comments.Add(pro);
                }
                return Ok(comments);
            }
        }

        [Route("{id}/Notes/{id1}", Name = "GetNotesByTeacherID")]
        public IHttpActionResult GetNotesByTeacherID([FromUri]string id, int id1)
        {
            var list = context.Tbl_Notes.Where(p => p.TeacherID == id && p.NotesID == id1);
            if (list.FirstOrDefault() == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                List<Tbl_Notes> comments = new List<Tbl_Notes>();
                foreach (var item in list)
                {
                    Tbl_Notes pro = new Tbl_Notes();
                    pro.NotesID = item.NotesID;
                    pro.TeacherID = item.TeacherID;
                    pro.Note = item.Note;
                    pro.SubjectID = item.SubjectID;
                    pro.SectionID = item.SectionID;
                    comments.Add(pro);
                }
                return Ok(comments);
            }

        }
        [Route("{id}/Notes")]
        public IHttpActionResult PostNote([FromBody]Tbl_Notes pro, [FromUri]string id)
        {


            pro.TeacherID = id;
            context.Tbl_Notes.Add(pro);
            context.SaveChanges();
            return Created(Url.Link("GetNotesByTeacherID", new { id = pro.TeacherID, id1 = pro.NotesID }), pro);
        }
       

        [Route("{id}/Notes/{id1}")]
        public IHttpActionResult DeleteComment([FromUri]string id, [FromUri]int id1)
        {
            var item = context.Tbl_Notes.Where(p => p.TeacherID == id && p.NotesID == id1).FirstOrDefault();
            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                context.Tbl_Notes.Remove(item);
                context.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }

        }



    }
}
