using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DIUB.Models;
using DIUB.Repository;

namespace DIUB.Controllers
{
    public class AdministrationOfficialController : BaseController
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        public List<SelectListItem> GetDepartment()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var cat = _unitOfWork.GetRepositoryInstance<Tbl_Department>().GetAllRecords();
            foreach (var item in cat)
            {
                list.Add(new SelectListItem { Value = item.DepartmentID.ToString(), Text = item.DepartmentName });
            }
            return list;
        }
        public List<SelectListItem> GetSalaryCategory()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var cat = _unitOfWork.GetRepositoryInstance <Tbl_SalaryCategory>().GetAllRecords();
            foreach (var item in cat)
            {
                list.Add(new SelectListItem { Value = item.SalaryCategoryID.ToString(), Text = item.Salary.ToString() });
            }
            return list;
        }
        public List<SelectListItem> GetSubject()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var cat = _unitOfWork.GetRepositoryInstance<Tbl_SubjectDetails>().GetAllRecords();
            foreach (var item in cat)
            {
                list.Add(new SelectListItem { Value = item.SubjectID.ToString(), Text = item.SubjectName +"("+item.Tbl_Department.DepartmentName+")" });
            }
            return list;
        }
        public List<SelectListItem> GetTeacher()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var cat = _unitOfWork.GetRepositoryInstance<Tbl_Teacher1>().GetAllRecords();
            foreach (var item in cat)
            {
                list.Add(new SelectListItem { Value = item.TeacherID, Text = item.FirstName +"  " + item.LastName+ "(" + item.Tbl_Department1.DepartmentName + ")" });
            }
            return list;
          
        }
        public List<SelectListItem> GetSemester()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var cat = _unitOfWork.GetRepositoryInstance<Tbl_Semester>().GetAllRecords();
            foreach (var item in cat)
            {
                list.Add(new SelectListItem { Value = item.SemesterID.ToString(), Text = item.SemesterName });
            }
            return list;
        }

        // GET: AdministrationOfficial
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StudentRegister()
        {
            ViewBag.DepartmentList = GetDepartment();
            return View();
        }
        [HttpPost]
        public ActionResult StudentRegister(Tbl_PreStudent tbl,Tbl_Accounts1 tbl1,HttpPostedFileBase file)
        {

            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/StudentImage/"), pic);
                file.SaveAs(path);
            }
            tbl.Picture = pic;
           
           
            _unitOfWork.GetRepositoryInstance<Tbl_PreStudent>().Add(tbl);
           /* tbl1.Email = tbl1.Email;
            tbl1.Password = tbl.Password;
            tbl1.Type = tbl.Type;
            tbl1.UserID = tbl.StudentID;
            _unitOfWork.GetRepositoryInstance<Tbl_Accounts>().Add(tbl1);*/
            return RedirectToAction("Index");
        }
        public ActionResult TeacherRegister()
        {
            ViewBag.DepartmentList = GetDepartment();
            ViewBag.SalaryCategoryList = GetSalaryCategory();
            return View();
        }
        [HttpPost]
        public ActionResult TeacherRegister(Tbl_PreTeacher tbl,Tbl_Accounts1 tbl1, HttpPostedFileBase file)
        {

            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/TeacherImage/"), pic);
                file.SaveAs(path);
            }
            tbl.Picture = pic;
           
            
           
            _unitOfWork.GetRepositoryInstance<Tbl_PreTeacher>().Add(tbl);
            /*
            tbl1.UserID = tbl.TeacherID;
            tbl1.Password = tbl.Password;
            tbl1.Email = tbl1.Email;
            tbl1.Type = tbl.Type;
            _unitOfWork.GetRepositoryInstance<Tbl_Accounts>().Add(tbl1);*/
            return RedirectToAction("Index");
        }
        public ActionResult EmployeeRegister()
        {
            ViewBag.DepartmentList = GetDepartment();
            ViewBag.SalaryCategoryList = GetSalaryCategory();
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeRegister(Tbl_PreEmployee tbl,Tbl_Accounts1 tbl1, HttpPostedFileBase file)
        {

            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/TeacherImage/"), pic);
                file.SaveAs(path);
            }
            tbl.Picture = pic;
            
            _unitOfWork.GetRepositoryInstance<Tbl_PreEmployee>().Add(tbl);
            /*
            tbl1.UserID = tbl.EmployeeID;
            tbl1.Password = tbl.Password;
            tbl1.Email = tbl1.Email;
            tbl1.Type = tbl.Type;

            _unitOfWork.GetRepositoryInstance<Tbl_Accounts>().Add(tbl1);*/
            return RedirectToAction("Index");
        }
        public ActionResult AddSubject()
        {
            ViewBag.DepartmentList = GetDepartment();
           
            return View();
        }
        [HttpPost]
        public ActionResult AddSubject(Tbl_PreSubjectDetails tbl)
        {

           
            _unitOfWork.GetRepositoryInstance<Tbl_PreSubjectDetails>().Add(tbl);
            return RedirectToAction("AddSubject");
        }
        public ActionResult AddSection()
        {
            ViewBag.SubjectList = GetSubject();
            ViewBag.TeachertList = GetTeacher();
            ViewBag.SemesterList = GetSemester();
            ViewBag.DepartmentList = GetDepartment();

            return View();
        }
        [HttpPost]
        public ActionResult AddSection(Tbl_PreSectionDistribution tbl)
        {


            _unitOfWork.GetRepositoryInstance<Tbl_PreSectionDistribution>().Add(tbl);
            return RedirectToAction("Index");
        }
        public ActionResult AddSemester()
        {
            ViewBag.SubjectList = GetSubject();

            return View();
        }
        [HttpPost]
        public ActionResult AddSemester(Tbl_Semester tbl)
        {


            _unitOfWork.GetRepositoryInstance<Tbl_Semester>().Add(tbl);
            return RedirectToAction("Index");
        }


    }
}