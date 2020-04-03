using DIUB.Models;
using DIUB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace DIUB.Controllers
{
    public class StudentController : BaseController
    {
        DIUBDatabaseEntities8 context = new DIUBDatabaseEntities8();
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        // GET: Student
        public List<SelectListItem> GetBooks()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var cat = _unitOfWork.GetRepositoryInstance<Tbl_Book>().GetAllRecords();
            foreach (var item in cat)
            {
                list.Add(new SelectListItem { Value = item.BookID.ToString(), Text = item.BookName + "("+item.Tbl_Category.CategoryName+")" });
            }
            return list;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registration()
        {
            String a =Session["UserID"].ToString();
           var x =  _unitOfWork.GetRepositoryInstance<Tbl_Student>().GetAllRecordsIQueryable().Where(m => m.StudentID == a).FirstOrDefault();
            var kal = _unitOfWork.GetRepositoryInstance<Tbl_Registration>().GetAllRecordsIQueryable().Where(m => m.StudentID == a);

            
            var show = _unitOfWork.GetRepositoryInstance<Tbl_SectionDistribution>().GetAllRecords().Where(m => m.DepartmentID == x.DepartmentID ).OrderBy(m => m.SubjectID);


            return View(show);
        }
        
        public ActionResult RegistrationConfirm(Tbl_Registration tbl,int id,int did,Tbl_SectionDistribution tbl1,Tbl_AttandanceMid atm,Tbl_AttandanceFinal atm1,Tbl_MidResult mid,Tbl_SemesterCost scost)
        {
            string a =Session["UserID"].ToString();
            var sectiondouble = _unitOfWork.GetRepositoryInstance<Tbl_Registration>().GetAllRecordsIQueryable().Where(x => x.StudentID == a && x.SectionID == id).FirstOrDefault();
            var cradit = _unitOfWork.GetRepositoryInstance<Tbl_Registration>().GetListParameter(x => x.StudentID == a && x.SemesterID == did).Sum(x => x.Credit);
           var take = _unitOfWork.GetRepositoryInstance<Tbl_SectionDistribution>().GetAllRecordsIQueryable().Where(x=> x.SectionID == id).FirstOrDefault();
           var l =  _unitOfWork.GetRepositoryInstance<Tbl_SubjectDetails>().GetAllRecordsIQueryable().Where(x => x.SubjectID == take.SubjectID).FirstOrDefault();
            //  var sid = _unitOfWork.GetRepositoryInstance<Tbl_SectionDistribution>().GetAllRecordsIQueryable().Where(x => x.SectionID == id).FirstOrDefault();
             var subj = _unitOfWork.GetRepositoryInstance<Tbl_SubjectDetails>().GetAllRecordsIQueryable().Where(x => x.SubjectID == take.SubjectID).FirstOrDefault();
            var m = _unitOfWork.GetRepositoryInstance<Tbl_Student>().GetAllRecordsIQueryable().Where(x => x.StudentID == a).FirstOrDefault();
            var kal = _unitOfWork.GetRepositoryInstance<Tbl_Registration>().GetAllRecordsIQueryable().Where(p => p.StudentID == a && p.SubjectName == take.Tbl_SubjectDetails.SubjectName).FirstOrDefault();
            var cost = _unitOfWork.GetRepositoryInstance<Tbl_SemesterCost>().GetAllRecordsIQueryable().Where(p => p.StudentID == a && p.SemesterIID == take.SemesterID).FirstOrDefault();
            var semestercount = _unitOfWork.GetRepositoryInstance<Tbl_SemesterCost>().GetAllRecordsIQueryable().Where(p => p.StudentID == a).Count();

            if (sectiondouble !=null && cradit.Value >16 && kal !=null)
            {
                Response.Write("<script>alert('Sorry! u have already taken this subject')</script>");


            }
            else { 
            
                tbl.StudentID = a;
                tbl.SectionID = id;
                tbl.SemesterID = did;
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
                atm.TeacherID = take.TeacherID;
                atm.SectionID = take.SectionID;
                atm.SectionName = take.SectionName;
                atm.SubjectID = take.SubjectID;
                atm.TeacherName = take.Tbl_Teacher1.FirstName+" "+take.Tbl_Teacher1.LastName;
                atm.StudentID = a;          
                atm.StudentName = m.FirstName+" " + m.LastName;
                atm1.TeacherID = take.TeacherID;
                atm1.SectionID = take.SectionID;
                atm1.SectionName = take.SectionName;
                atm1.SubjectID = take.SubjectID;
                atm1.TeacherName = take.Tbl_Teacher1.FirstName+" "+take.Tbl_Teacher1.LastName;
                atm1.StudentID = a;
                atm1.StudentName = m.FirstName+" " + m.LastName;
                mid.TeacherID = take.TeacherID; 
               // mid.TeacherName = take.Tbl_Teacher1.FirstName + " " + take.Tbl_Teacher1.LastName;
                mid.StudentID = a;
                //mid.StudentName = m.FirstName + " " + m.LastName;
                mid.SectionID = take.SectionID;
                mid.SubjectID = take.SubjectID;
                mid.SemesterID = take.SemesterID;
                
                decimal lab = 0;
                if(cost != null)
                {
                    if(semestercount%3 == 0)
                    { var kk = _unitOfWork.GetRepositoryInstance<Tbl_Expense>().GetAllRecordsIQueryable().Where(x => x.ExpenseName == "DevelopmentFee").FirstOrDefault();
                      var ll = _unitOfWork.GetRepositoryInstance<Tbl_Expense>().GetAllRecordsIQueryable().Where(x => x.ExpenseName == "Activity").FirstOrDefault();
                        scost.Development = kk.Cost;
                        scost.Activity = ll.Cost;
                    }
                    else
                    {
                        scost.Development = 0;
                        scost.Activity = 0;
                    }
                    if(subj.IsLabExist == "yes")
                    {
                        var kl = _unitOfWork.GetRepositoryInstance<Tbl_Expense>().GetAllRecordsIQueryable().Where(x => x.ExpenseName == "ComputerLab").FirstOrDefault();
                        lab = (decimal)cost.ComputerLab;
                        scost.ComputerLab =lab+ kl.Cost;
                    }
                    else
                    {
                        scost.ComputerLab = 0;
                    }
                    var jl = _unitOfWork.GetRepositoryInstance<Tbl_Expense>().GetAllRecordsIQueryable().Where(x => x.ExpenseName == "Credit").FirstOrDefault();
                    var jj = _unitOfWork.GetRepositoryInstance<Tbl_Expense>().GetAllRecordsIQueryable().Where(x => x.ExpenseName == "Miscellaneous").FirstOrDefault();

                    int credit = (int)cost.CreditTaken;
                    scost.CreditTaken = credit + take.Credit;
                    scost.StudentID = a;
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
                   _unitOfWork.GetRepositoryInstance<Tbl_SemesterCost>().RemovebyWhereClause(x => x.StudentID == a && x.SemesterIID == take.SemesterID);
                    _unitOfWork.GetRepositoryInstance<Tbl_SemesterCost>().Add(scost);
                    

                }
                else
                {
                    var jj = _unitOfWork.GetRepositoryInstance<Tbl_Expense>().GetAllRecordsIQueryable().Where(x => x.ExpenseName == "Miscellaneous").FirstOrDefault();
                    var uj = _unitOfWork.GetRepositoryInstance<Tbl_Expense>().GetAllRecordsIQueryable().Where(x => x.ExpenseName == "Admission").FirstOrDefault();
                    var kk = _unitOfWork.GetRepositoryInstance<Tbl_Expense>().GetAllRecordsIQueryable().Where(x => x.ExpenseID == 7).FirstOrDefault();
                    var ll = _unitOfWork.GetRepositoryInstance<Tbl_Expense>().GetAllRecordsIQueryable().Where(x => x.ExpenseName == "Activity").FirstOrDefault();
                    scost.SemesterIID = take.SemesterID;
                    scost.StudentID = a;
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
                        var kl = _unitOfWork.GetRepositoryInstance<Tbl_Expense>().GetAllRecordsIQueryable().Where(x => x.ExpenseName == "ComputerLab").FirstOrDefault();
                        lab = (decimal)cost.ComputerLab;
                        scost.ComputerLab = kl.Cost;
                    }
                    else
                    {
                        scost.ComputerLab = 0;
                    }
                    var jl = _unitOfWork.GetRepositoryInstance<Tbl_Expense>().GetAllRecordsIQueryable().Where(x => x.ExpenseName == "Credit").FirstOrDefault();

                     scost.Total =  (scost.CreditTaken) * jl.Cost + scost.Development + scost.Activity + lab;
                    _unitOfWork.GetRepositoryInstance<Tbl_SemesterCost>().Add(scost);



                }

                _unitOfWork.GetRepositoryInstance<Tbl_Registration>().Add(tbl);
                _unitOfWork.GetRepositoryInstance<Tbl_AttandanceMid>().Add(atm);
                _unitOfWork.GetRepositoryInstance<Tbl_AttandanceFinal>().Add(atm1);
                _unitOfWork.GetRepositoryInstance<Tbl_MidResult>().Add(mid);
               

            }

            return RedirectToAction("Registration", "Student");
            
        }
        public ActionResult AddCart(int sectionId)
        {
            if (Session["cart"] == null)
            {
                List<RegistrationItem> cart = new List<RegistrationItem>();
                var section = context.Tbl_SectionDistribution.Find(sectionId);
                cart.Add(new RegistrationItem()
                {
                    Section = section,
                    CreditTotal = Convert.ToInt32(section.Credit)
                });
                Session["cart"] = cart;
            }
            else
            {
                List<RegistrationItem> cart = (List<RegistrationItem>)Session["cart"];
                var section = context.Tbl_SectionDistribution.Find(sectionId);
                foreach (var item in cart)
                {
                    if (item.Section.SectionID == sectionId)
                    {
                        int prevQty = item.CreditTotal;
                        cart.Remove(item);
                        cart.Add(new RegistrationItem()
                        {
                            Section = section,
                            CreditTotal = prevQty + Convert.ToInt32(section.Credit)
                        });
                        break;
                    }
                    else
                    {
                        cart.Add(new RegistrationItem()
                        {
                            Section = section,
                            CreditTotal = Convert.ToInt32(section.Credit)
                        });
                        break;
                    }

                }
                Session["cart"] = cart;

            }
            return Redirect("Registration");
        }
        public ActionResult RemoveFromCart(int sectionID)
        {
            List<RegistrationItem> cart = (List<RegistrationItem>)Session["cart"];
            //var product = context.Tbl_Product.Find(productId);
            foreach (var item in cart)
            {
                if (item.Section.SectionID == sectionID)
                {
                    cart.Remove(item);
                    break;
                }
            }

            Session["cart"] = cart;
            return Redirect("Registration");
        }
        public ActionResult RegistrationShow()
        {
            return View();
        }
       
        public ActionResult SeeNotes(int id)
        {
            
            string a = Session["userID"].ToString();
            
            var l = _unitOfWork.GetRepositoryInstance<Tbl_Notes>().GetAllRecordsIQueryable().Where(x => x.SectionID == id);

            return View(l);
        }
        public FileResult Download(string picture)
        {
            var FileVirtualPath = "~/Notes/" + picture;
            return File(FileVirtualPath, "application/force - download", System.IO.Path.GetFileName(FileVirtualPath));
        }
        
        public ActionResult ShowclassSchedule()
        {
            ViewBag.SemesterList = GetSemester();
            string o = Session["userID"].ToString();
            var l = _unitOfWork.GetRepositoryInstance<Tbl_Semester>().GetAllRecords().LastOrDefault();
            var p = _unitOfWork.GetRepositoryInstance<Tbl_Registration>().GetAllRecordsIQueryable().Where(x => x.StudentID == o && x.SemesterID == l.SemesterID);
          



            return View(p);
        }
        public ActionResult ShowSubjectStudent(int sectionID)
        {
            
            string o = Session["userID"].ToString();
           
           
            var l = _unitOfWork.GetRepositoryInstance<Tbl_SectionDistribution>().GetAllRecordsIQueryable().Where(x => x.SectionID == sectionID).FirstOrDefault();


            return View(l);
        }
        public ActionResult ShowFinencial()
        {

            string o = Session["userID"].ToString();


            var l = _unitOfWork.GetRepositoryInstance<Tbl_SemesterCost>().GetAllRecordsIQueryable().Where(x => x.StudentID == o);


            return View(l);
        }
        public ActionResult ShowSemesterCost(int id)
        {

            string o = Session["userID"].ToString();


            var l = _unitOfWork.GetRepositoryInstance<Tbl_SemesterCost>().GetAllRecordsIQueryable().Where(x => x.SemesterCostID == id).FirstOrDefault();


            return View(l);
        }
        public ActionResult CourseResult(int sectionID)
        {

            string o = Session["userID"].ToString();


            var l = _unitOfWork.GetRepositoryInstance<Tbl_SemesterCost>().GetAllRecordsIQueryable().Where(x => x.SemesterCostID == sectionID).FirstOrDefault();


            return View(l);
        }
        public List<SelectListItem> GetSemester()
        {
            string a = Session["userID"].ToString();
            List<SelectListItem> list = new List<SelectListItem>();
            var cat = _unitOfWork.GetRepositoryInstance<Tbl_Registration>().GetAllRecordsIQueryable().Where(x=>x.StudentID == a);
            foreach (var item in cat)
            {
                list.Add(new SelectListItem { Value = item.SemesterID.ToString(), Text = item.Tbl_Semester.SemesterName.ToString() });
            }
            return list;
        }
        
        public ActionResult RegistaredShow(int semesterID,int? page)
        {

            string o = Session["userID"].ToString();
            RegistrationViewPage model = new RegistrationViewPage();
            
            return View(model.CreateModel(o,semesterID, 20, page));
        }
        public ActionResult MarksPerSubject()
        {
            string a = Session["userID"].ToString();
            return View(_unitOfWork.GetRepositoryInstance<Tbl_MidResult>().GetAllRecordsIQueryable().Where(x => x.StudentID == a).OrderBy(x => x.SectionID));
        }
        public ActionResult UploadLabTask(int id)
        {
            
            return View(_unitOfWork.GetRepositoryInstance<Tbl_MidResult>().GetFirstorDefault(id));
        }
        [HttpPost]
        public ActionResult UploadLabTask(Tbl_MidResult tbl,HttpPostedFileBase file, HttpPostedFileBase file1, HttpPostedFileBase file2, HttpPostedFileBase file3, HttpPostedFileBase file4)
        {
            string lab1 = null;
            string lab2 = null;
            string lab3 = null;
            string lab4 = null;
            string lab5 = null;
            if (file != null)
            {
                lab1 = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/LabTask/"), lab1);
                file.SaveAs(path);
            }
            tbl.Lab01 = lab1;
            if (file1 != null)
            {
                lab2 = System.IO.Path.GetFileName(file1.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/LabTask/"), lab2);
                file1.SaveAs(path);
            }
            tbl.Lab02 = lab2;
            if (file2 != null)
            {
                lab3 = System.IO.Path.GetFileName(file2.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/LabTask/"), lab3);
                file2.SaveAs(path);
            }
            tbl.Lab03 = lab3;
            if (file3 != null)
            {
                lab4 = System.IO.Path.GetFileName(file3.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/LabTask/"), lab4);
                file3.SaveAs(path);
            }
            tbl.Lab04 = lab4;
            if (file4 != null)
            {
                lab5 = System.IO.Path.GetFileName(file4.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/LabTask/"), lab5);
                file4.SaveAs(path);
            }
            tbl.LabMid = lab5;
            _unitOfWork.GetRepositoryInstance<Tbl_MidResult>().Update(tbl);
            return RedirectToAction("Index");
        }

        public ActionResult BookRequest()
        {

            ViewBag.BookList = GetBooks();

            return View();
        }
        //[HttpPost]
        //public ActionResult BookRequest(Tbl_Request tbl)
        //{
        //    string ll = Session["userID"].ToString();

        //    tbl.StudentID = ll;
            
            

        //   _unitOfWork.GetRepositoryInstance<Tbl_Request>().Add(tbl);


        //    return RedirectToAction("Index");
        //}
        //public ActionResult BookNew1()
        //{
        //    var show = _unitOfWork.GetRepositoryInstance<Tbl_Book>().GetAllRecords().OrderBy(x => x.BuyingDate).Reverse();
        //    return View(show);
        //}
        //public ActionResult BookOld1()
        //{
        //    var show = _unitOfWork.GetRepositoryInstance<Tbl_Book>().GetAllRecords().OrderBy(x => x.BuyingDate);
        //    return View(show);
        //}
        public ActionResult ShowBook(string search,int? page)
        {
            BookIndexViewModel model = new BookIndexViewModel();

            return View(model.CreateModel(search, 20, page));
        }
       


    }
}