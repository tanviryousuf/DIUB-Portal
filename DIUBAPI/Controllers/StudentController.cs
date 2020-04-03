using DIUBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DIUBAPI.Controllers
{
    [RoutePrefix("api/Students")]
    public class StudentController : ApiController
    {
        DIUBDatabaseEntities context = new DIUBDatabaseEntities();
        [Route("")]
        public IHttpActionResult Get()
        {
            var list = context.Tbl_Student.ToList();
            List<Tbl_Student> categories = new List<Tbl_Student>();
            foreach (var item in list)
            {
                Tbl_Student cat = new Tbl_Student();
                cat.SerialID = item.SerialID;
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

                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Students", Method = "GET", Rel = "Self" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Students/" + cat.StudentID, Method = "GET", Rel = "Specific Resource" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Students/" + cat.StudentID, Method = "PUT", Rel = "Resource Edit" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Students/" + cat.StudentID, Method = "DELETE", Rel = "Resource Delete" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Students", Method = "POST", Rel = "Resource Create" });

                categories.Add(cat);
            }
            return Ok(categories);
        }
        [Route("{id}", Name = "GetStudentById")]
        public IHttpActionResult Get(string id)
        {
            var item = context.Tbl_Student.Where(p => p.StudentID == id).FirstOrDefault();
            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                Tbl_Student cat = new Tbl_Student();
                cat.SerialID = item.SerialID;
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

                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Students", Method = "GET", Rel = "Self" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Students/" + cat.StudentID, Method = "GET", Rel = "Specific Resource" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Students/" + cat.StudentID, Method = "PUT", Rel = "Resource Edit" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Students/" + cat.StudentID, Method = "DELETE", Rel = "Resource Delete" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Students", Method = "POST", Rel = "Resource Create" });
                return Ok(cat);
            }

        }
        [Route("")]
        public IHttpActionResult Post([FromBody]Tbl_PreStudent pre)
        {
            var item = context.Tbl_PreStudent.Where(x => x.StudentID == pre.StudentID).FirstOrDefault();

            Tbl_Student cat = new Tbl_Student();
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
            Tbl_Accounts1 ac = new Tbl_Accounts1();

            ac.UserID = pre.StudentID;
            ac.Password = item.Password;
            ac.Type = item.Type;

            context.Tbl_Student.Add(cat);
            context.Tbl_Accounts1.Add(ac);
            context.Tbl_PreStudent.Remove(item);
            context.SaveChanges();
            return Created(Url.Link("GetStudentById", new { id = cat.StudentID }), cat);
        }
        [Route("{id}")]
        public IHttpActionResult Put([FromUri]string id, [FromBody]Tbl_Student item)
        {
            var cat = context.Tbl_Student.Where(p => p.StudentID == id).FirstOrDefault();
            if (cat == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                cat.SerialID = item.SerialID;
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
            var item = context.Tbl_Student.Where(p => p.StudentID == id).FirstOrDefault();
            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                context.Tbl_Student.Remove(item);
                context.SaveChanges();
                return StatusCode(HttpStatusCode.NoContent);
            }

        }
        [Route("{id}/Registration", Name = "GetRegistrationByStudentID")]
        public IHttpActionResult GetRegistrationByStudentID([FromUri]string id )
        {

            var list = context.Tbl_Registration.Where(p => p.StudentID == id );
            if (list.FirstOrDefault() == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                List<Tbl_Registration> comments = new List<Tbl_Registration>();
                foreach (var item in list)
                {
                    Tbl_Registration tbl = new Tbl_Registration();
                    tbl.StudentID = id;
                    tbl.SectionID = item.SectionID;
                    tbl.SemesterID = item.SemesterID;
                    tbl.Available = item.Available;
                    tbl.Capacity = item.Capacity;
                    tbl.ClassStart = item.ClassStart;
                    tbl.ClassEnd = item.ClassEnd;
                    tbl.Day1 = item.Day1;
                    tbl.Day2 = item.Day2;
                    tbl.IsValid = item.IsValid;
                    tbl.SubjectName = item.SubjectName;
                    tbl.Credit = item.Credit;
                    tbl.ClassStart2 = item.ClassStart2;
                    tbl.ClassEnd2 = item.ClassEnd2;
                    tbl.SectionName = item.SectionName;
                    tbl.TeacherID = item.TeacherID;
                    tbl.links.Add(new Links() { HRef = "http://localhost:57254/api/Students/" + id + "/Registration", Method = "GET", Rel = "Self" });
                   
                    tbl.links.Add(new Links() { HRef = "http://localhost:57254/api/Students/" + id + "/Registration", Method = "POST", Rel = "Resource Create" });
                    comments.Add(tbl);
                }
                return Ok(comments);
            }
        }
        [Route("{id}/{Registration}")]
        public IHttpActionResult PostRegistration([FromUri]string id, [FromBody]Tbl_SectionDistribution sec)
        {
            var kl = context.Tbl_SectionDistribution.Where(x => x.SectionID == sec.SectionID).FirstOrDefault();
            var sectiondouble = context.Tbl_Registration.Where(x => x.StudentID == id && x.SectionID == sec.SectionID).FirstOrDefault();
            var cradit = context.Tbl_Registration.Where(x => x.StudentID == id && x.SemesterID == kl.SemesterID).Sum(x => x.Credit);
            var take = context.Tbl_SectionDistribution.Where(x => x.SectionID == sec.SectionID).FirstOrDefault();
            var l = context.Tbl_SubjectDetails.Where(x => x.SubjectID == take.SubjectID).FirstOrDefault();
            //  var sid = _unitOfWork.GetRepositoryInstance<Tbl_SectionDistribution>().GetAllRecordsIQueryable().Where(x => x.SectionID == id).FirstOrDefault();
            var subj = context.Tbl_SubjectDetails.Where(x => x.SubjectID == take.SubjectID).FirstOrDefault();
            var m = context.Tbl_Student.Where(x => x.StudentID == id).FirstOrDefault();
            var kal = context.Tbl_Registration.Where(p => p.StudentID == id && p.SubjectName == take.Tbl_SubjectDetails.SubjectName).FirstOrDefault();
            var cost = context.Tbl_SemesterCost.Where(p => p.StudentID == id && p.SemesterIID == take.SemesterID).FirstOrDefault();
            var semestercount = context.Tbl_SemesterCost.Where(p => p.StudentID == id).Count();

            if (sectiondouble != null && cradit.Value > 16 && kal != null)
            {
                return StatusCode(HttpStatusCode.NotFound);


            }
            else
            {
                Tbl_Registration tbl = new Tbl_Registration();
                tbl.StudentID = id;
                tbl.SectionID = take.SectionID;
                tbl.SemesterID = take.SemesterID;
                tbl.Available = take.Available;
                tbl.Capacity = take.Capacity;
                tbl.ClassStart = take.ClassStart;
                tbl.ClassEnd = take.ClassEnd;
                tbl.Day1 = take.Day1;
                tbl.Day2 = take.Day2;
                tbl.IsValid = false;
                tbl.SubjectName = l.SubjectName;
                tbl.Credit = take.Credit;
                tbl.ClassStart2 = take.ClassStart2;
                tbl.ClassEnd2 = take.ClassEnd2;
                tbl.SectionName = take.SectionName;
                tbl.TeacherID = take.TeacherID;
                Tbl_MidResult mid = new Tbl_MidResult();
                mid.TeacherID = take.TeacherID;
                // mid.TeacherName = take.Tbl_Teacher1.FirstName + " " + take.Tbl_Teacher1.LastName;
                mid.StudentID = id;
                //mid.StudentName = m.FirstName + " " + m.LastName;
                mid.SectionID = take.SectionID;
                mid.SubjectID = take.SubjectID;
                mid.SemesterID = take.SemesterID;
                Tbl_SemesterCost scost = new Tbl_SemesterCost();
                decimal lab = 0;
                if (cost != null)
                {
                    if (semestercount % 3 == 0)
                    {
                        var kk = context.Tbl_Expense.Where(x => x.ExpenseName == "DevelopmentFee").FirstOrDefault();
                        var ll = context.Tbl_Expense.Where(x => x.ExpenseName == "Activity").FirstOrDefault();
                        scost.Development = kk.Cost;
                        scost.Activity = ll.Cost;
                    }
                    else
                    {
                        scost.Development = 0;
                        scost.Activity = 0;
                    }
                    if (subj.IsLabExist == "yes")
                    {
                        var kla = context.Tbl_Expense.Where(x => x.ExpenseName == "ComputerLab").FirstOrDefault();
                        lab = (decimal)cost.ComputerLab;
                        scost.ComputerLab = lab + kla.Cost;
                    }
                    else
                    {
                        scost.ComputerLab = 0;
                    }
                    var jl = context.Tbl_Expense.Where(x => x.ExpenseName == "Credit").FirstOrDefault();
                    var jj = context.Tbl_Expense.Where(x => x.ExpenseName == "Miscellaneous").FirstOrDefault();

                    int credit = (int)cost.CreditTaken;
                    scost.CreditTaken = credit + take.Credit;
                    scost.StudentID = id;
                    scost.SemesterIID = take.SemesterID;
                    scost.LanguageLab = 0;
                    scost.Miscellaneous = jj.Cost;
                    scost.PreviousDue = 0;
                    scost.ScienceLab = 0;
                    scost.AdmissionFee = cost.AdmissionFee;
                    scost.Studio = 0;
                    scost.AmountPaid = 0;

                    decimal prev = (decimal)cost.Total;
                    scost.Total = prev + (scost.CreditTaken - credit) * jl.Cost + scost.Development + scost.Activity + lab;
                    scost.Due = scost.Total - scost.AmountPaid;
                    var seme = context.Tbl_SemesterCost.Where(x => x.StudentID == id && x.SemesterIID == take.SemesterID).FirstOrDefault();
                    context.Tbl_SemesterCost.Remove(seme);
                    context.Tbl_SemesterCost.Add(scost);
                    context.SaveChanges();


                }
                else
                {
                    var jj = context.Tbl_Expense.Where(x => x.ExpenseName == "Miscellaneous").FirstOrDefault();
                    var uj = context.Tbl_Expense.Where(x => x.ExpenseName == "Admission").FirstOrDefault();
                    var kk = context.Tbl_Expense.Where(x => x.ExpenseID == 7).FirstOrDefault();
                    var ll = context.Tbl_Expense.Where(x => x.ExpenseName == "Activity").FirstOrDefault();
                    scost.SemesterIID = take.SemesterID;
                    scost.StudentID = id;
                    scost.LanguageLab = 0;
                    scost.Miscellaneous = jj.Cost;
                    scost.PreviousDue = 0;
                    scost.ScienceLab = 0;
                    scost.Studio = 0;
                    scost.AmountPaid = 0;
                    scost.AdmissionFee = uj.Cost;
                    scost.CreditTaken = take.Credit;
                    if (semestercount % 3 == 0)
                    {

                        scost.Development = kk.Cost;
                        scost.Activity = ll.Cost;
                    }
                    else
                    {
                        scost.Development = 0;
                        scost.Activity = 0;
                    }
                    if (subj.IsLabExist == "yes")
                    {
                        var kla = context.Tbl_Expense.Where(x => x.ExpenseName == "ComputerLab").FirstOrDefault();
                        lab = (decimal)cost.ComputerLab;
                        scost.ComputerLab = kla.Cost;
                    }
                    else
                    {
                        scost.ComputerLab = 0;
                    }
                    var jl = context.Tbl_Expense.Where(x => x.ExpenseName == "Credit").FirstOrDefault();

                    scost.Total = (scost.CreditTaken) * jl.Cost + scost.Development + scost.Activity + lab;
                    context.Tbl_SemesterCost.Add(scost);
                    context.SaveChanges();



                }

                context.Tbl_Registration.Add(tbl);

                context.Tbl_MidResult.Add(mid);
                context.SaveChanges();
                return Created(Url.Link("GetRegistrationByStudentID", new { id = tbl.StudentID,id1 = tbl.RegID }), tbl);
            }
        }
        [Route("{id}/MarksOfStudents")]
        public IHttpActionResult GetMarksOfStudents([FromUri]String id)
        {
            var list = context.Tbl_MidResult.Where(p => p.StudentID == id).OrderBy(x => x.SectionID);
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



                    pro.links.Add(new Links() { HRef = "http://localhost:57254/api/Students/" + id + "/MarksOfStudents", Method = "GET", Rel = "Self" });
                    pro.links.Add(new Links() { HRef = "http://localhost:57254/api/Students/" + id + "/MarksOfStudents/" + pro.ResultID, Method = "GET", Rel = "Specific Resource" });
                    pro.links.Add(new Links() { HRef = "http://localhost:57254/api/Students/" + id + "/MarksOfStudents/" + pro.ResultID, Method = "PUT", Rel = "Resource Edit" });
                    
                    comments.Add(pro);
                }
                return Ok(comments);
            }
        }
          [Route("{id}/MarksOfStudents/{id1}", Name = "GetMarksByStudentID")]
        public IHttpActionResult GetMarksByStudentID([FromUri]string id, int id1)
        {
            var list = context.Tbl_MidResult.Where(p => p.StudentID == id && p.ResultID == id1);
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
                    pro.links.Add(new Links() { HRef = "http://localhost:57254/api/Students/" + id + "/MarksOfStudents", Method = "GET", Rel = "Self" });
                    pro.links.Add(new Links() { HRef = "http://localhost:57254/api/Students/" + id + "/MarksOfStudents/" + pro.ResultID, Method = "GET", Rel = "Specific Resource" });
                    pro.links.Add(new Links() { HRef = "http://localhost:57254/api/Students/" + id + "/MarksOfStudents/" + pro.ResultID, Method = "PUT", Rel = "Resource Edit" });

                    comments.Add(pro);
                }
                return Ok(comments);
            }

        }
        [Route("{id}/FinencialCosts")]
        public IHttpActionResult GetFinencialCostByStudent([FromUri]string id)
        {
            var list = context.Tbl_SemesterCost.Where(p => p.StudentID == id);
            if (list.FirstOrDefault() == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                List<Tbl_SemesterCost> comments = new List<Tbl_SemesterCost>();
                foreach (var item in list)
                {
                    Tbl_SemesterCost pro = new Tbl_SemesterCost();
                    pro.SemesterCostID = item.SemesterCostID;
                    pro.SemesterIID = item.SemesterIID;
                    pro.StudentID = id;
                    pro.Activity = item.Activity;
                    pro.AdmissionFee = item.AdmissionFee;
                    pro.ComputerLab = item.ComputerLab;
                    pro.CreditTaken = item.CreditTaken;
                    pro.Development = item.Development;
                    pro.LanguageLab = item.LanguageLab;
                    pro.Studio = item.Studio;
                    pro.Miscellaneous = item.Miscellaneous;
                    pro.ScienceLab = item.ScienceLab;
                    pro.PreviousDue = item.PreviousDue;
                    pro.AmountPaid = item.AmountPaid;
                    pro.Total = item.Total;
                    pro.links.Add(new Links() { HRef = "http://localhost:57254/api/Students/" + id + "/FinencialCosts", Method = "GET", Rel = "Self" });
                    pro.links.Add(new Links() { HRef = "http://localhost:57254/api/Students/" + id + "/FinencialCosts/" + pro.SemesterCostID, Method = "GET", Rel = "Specific Resource" });
                    comments.Add(pro);
                }
                return Ok(comments);
            }
        }

        [Route("{id}/FinencialCosts/{id1}", Name = "GetCostPerSemester")]
        public IHttpActionResult GetCommentByPostID([FromUri]string id, int id1)
        {
            var item = context.Tbl_SemesterCost.Where(p => p.StudentID == id && p.SemesterCostID == id1).FirstOrDefault();
            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                List<Tbl_SemesterCost> comments = new List<Tbl_SemesterCost>();
                
                    Tbl_SemesterCost pro = new Tbl_SemesterCost();
                    pro.SemesterCostID = item.SemesterCostID;
                    pro.SemesterIID = item.SemesterIID;
                    pro.StudentID = id;
                    pro.Activity = item.Activity;
                    pro.AdmissionFee = item.AdmissionFee;
                    pro.ComputerLab = item.ComputerLab;
                    pro.CreditTaken = item.CreditTaken;
                    pro.Development = item.Development;
                    pro.LanguageLab = item.LanguageLab;
                    pro.Studio = item.Studio;
                    pro.Miscellaneous = item.Miscellaneous;
                    pro.ScienceLab = item.ScienceLab;
                    pro.PreviousDue = item.PreviousDue;
                    pro.AmountPaid = item.AmountPaid;
                    pro.Total = item.Total;
                    pro.links.Add(new Links() { HRef = "http://localhost:57254/api/Students/" + id + "/FinencialCosts", Method = "GET", Rel = "Self" });
                    pro.links.Add(new Links() { HRef = "http://localhost:57254/api/Students/" + id + "/FinencialCosts/" + pro.SemesterCostID, Method = "GET", Rel = "Specific Resource" });
                
                return Ok(comments);
            }

        }
        
        [Route("{id}/UploadLabTask/{id1}")]
        public IHttpActionResult PutComment([FromUri]string id, [FromUri]int id1, [FromBody]Tbl_MidResult item)
        {
            var pro = context.Tbl_MidResult.Where(p => p.StudentID == id && p.ResultID == id1).FirstOrDefault();
            if (pro == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
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
                pro.Lab01 = item.Lab01;
                pro.Lab02 = item.Lab02;
                pro.Lab03 = item.Lab03;
                pro.Lab04 = item.Lab04;
                pro.FinalFinal = item.FinalFinal;
                pro.TotalMarksFinal = item.TotalMarksFinal;
                pro.GradeFinal = item.GradeFinal;
                pro.TotalMarks = item.TotalMarks;
                pro.Grade = item.Grade;

                pro.LabFinal = item.LabFinal;
                context.SaveChanges();
                item.Tbl_Student = new Tbl_Student();
                return Ok(item);
            }

        }

        

    }
}
