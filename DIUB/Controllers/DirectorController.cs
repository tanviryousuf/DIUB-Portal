using DIUB.Models;
using DIUB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DIUB.Controllers
{
    public class DirectorController : BaseController
    {
        // GET: Director
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult StudentRegistrationConfirm()
        {
            String a = Session["UserID"].ToString();
            var k = _unitOfWork.GetRepositoryInstance<Tbl_Teacher1>().GetAllRecordsIQueryable().Where(x => x.TeacherID == a).FirstOrDefault();
            var l = _unitOfWork.GetRepositoryInstance<Tbl_PreStudent>().GetAllRecordsIQueryable().Where(x => x.DepartmentID == k.DepartmentID);
           
            return View(l);
        }
        public ActionResult ConfirmStudent(int id,Tbl_Student tbl,Tbl_PreStudent tbl1,Tbl_Accounts1 tbl2)
        {
            Tbl_PreStudent k = _unitOfWork.GetRepositoryInstance<Tbl_PreStudent>().GetAllRecordsIQueryable().Where(x => x.ConfrimID == id).FirstOrDefault();
            
            tbl.StudentID = k.StudentID;
            tbl.FatherName = k.FatherName;
            tbl.FirstName = k.FirstName;
            tbl.LastName = k.LastName;
            tbl.MotherName = k.MotherName;
            tbl.GraduationDate = k.GraduationDate;
            tbl.MaritalStatus = k.MaritalStatus;
            tbl.Nationality = k.Nationality;
            tbl.Password = k.Password;
            tbl.PresentAddress = k.PresentAddress;
            tbl.PermanentAddress = k.PermanentAddress;
            tbl.Phone = k.Phone;
            tbl.Picture = k.Picture;
            tbl.Religion = k.Religion;
            tbl.Sex = k.Sex;
            tbl.Email = k.Email;
            tbl.DocumentsGiven = k.DocumentsGiven;
            tbl.DepartmentID = k.DepartmentID;
            tbl.BloodGroup = k.BloodGroup;
            tbl.BirthDate = k.BirthDate;
            tbl.Type = k.Type;
            tbl.AdmissionDate = k.AdmissionDate;
            tbl.PerSemesterRecordID = k.PerSemesterRecordID;
            _unitOfWork.GetRepositoryInstance<Tbl_Student>().Add(tbl);
            _unitOfWork.GetRepositoryInstance<Tbl_PreStudent>().Remove(k);
            tbl2.Status = "Active";
            tbl2.Password = tbl.Password;
            tbl2.Type = tbl.Type;
            tbl2.UserID = tbl.StudentID;
            _unitOfWork.GetRepositoryInstance<Tbl_Accounts1>().Add(tbl2);


            return RedirectToAction("StudentRegistrationConfirm");
        }
        public ActionResult StudentDetails(int id)
        {
            Tbl_PreStudent k = _unitOfWork.GetRepositoryInstance<Tbl_PreStudent>().GetAllRecordsIQueryable().Where(x => x.ConfrimID == id).FirstOrDefault();
            return View(k);
        }
        public ActionResult SubjectConfirm()
        {
            String a = Session["UserID"].ToString();
            var k = _unitOfWork.GetRepositoryInstance<Tbl_Teacher1>().GetAllRecordsIQueryable().Where(x => x.TeacherID == a).FirstOrDefault();
            var l = _unitOfWork.GetRepositoryInstance<Tbl_PreSubjectDetails>().GetAllRecordsIQueryable().Where(x => x.DepartmentID == k.DepartmentID);

            return View(l);
        }
        public ActionResult ConfirmSubject(int id, Tbl_SubjectDetails tbl, Tbl_PreSubjectDetails tbl1)
        {
            Tbl_PreSubjectDetails k = _unitOfWork.GetRepositoryInstance<Tbl_PreSubjectDetails>().GetAllRecordsIQueryable().Where(x => x.SubjectID == id).FirstOrDefault();
            

            tbl.SubjectID = k.SubjectID;
            tbl.SubjectName = k.SubjectName;
            tbl.IsLabExist = k.IsLabExist;
            tbl.Credit = k.Credit;
            tbl.DepartmentID = k.DepartmentID;
           
            _unitOfWork.GetRepositoryInstance<Tbl_SubjectDetails>().Add(tbl);
            _unitOfWork.GetRepositoryInstance<Tbl_PreSubjectDetails>().Remove(k);


            return RedirectToAction("SubjectConfirm");
        }
        public ActionResult SubjectDetails(int id)
        {
            Tbl_PreSubjectDetails k = _unitOfWork.GetRepositoryInstance<Tbl_PreSubjectDetails>().GetAllRecordsIQueryable().Where(x => x.SubjectID == id).FirstOrDefault();
            return View(k);
        }
        public ActionResult CancelSubject(int id)
        {
            Tbl_PreSubjectDetails k = _unitOfWork.GetRepositoryInstance<Tbl_PreSubjectDetails>().GetAllRecordsIQueryable().Where(x => x.SubjectID == id).FirstOrDefault();
            _unitOfWork.GetRepositoryInstance<Tbl_PreSubjectDetails>().Remove(k);
            return RedirectToAction("SubjectConfirm");
        }
        public ActionResult SectionConfirm()
        {
            String a = Session["UserID"].ToString();
            var k = _unitOfWork.GetRepositoryInstance<Tbl_Teacher1>().GetAllRecordsIQueryable().Where(x => x.TeacherID == a).FirstOrDefault();
            var l = _unitOfWork.GetRepositoryInstance<Tbl_PreSectionDistribution>().GetAllRecordsIQueryable().Where(x => x.DepartmentID == k.DepartmentID);

            return View(l);
        }
        public ActionResult ConfirmSection(int id, Tbl_SectionDistribution tbl, Tbl_PreSectionDistribution tbl1)
        {
            Tbl_PreSectionDistribution k = _unitOfWork.GetRepositoryInstance<Tbl_PreSectionDistribution>().GetAllRecordsIQueryable().Where(x => x.SectionID == id).FirstOrDefault();

            tbl.SectionID = k.SectionID;
            tbl.SubjectID = k.SubjectID;
            tbl.SectionName = k.SectionName;
            tbl.Available = k.Available;
            tbl.Credit = k.Credit;
            tbl.Capacity = k.Capacity;
            tbl.DepartmentID = k.DepartmentID;
           
          
            tbl.SemesterID = k.SemesterID;
            tbl.Available = k.Available;
            tbl.Capacity = k.Capacity;
            tbl.ClassStart = k.ClassStart;
            tbl.ClassEnd = k.ClassEnd;
            tbl.Day1 = k.Day1;
            tbl.Day2 = k.Day2;
            
            tbl.Credit = k.Credit;
            tbl.ClassStart2 = k.ClassStart2;
            tbl.ClassEnd2 = k.ClassEnd2;
            tbl.SectionName = k.SectionName;
            tbl.TeacherID = k.TeacherID;

            _unitOfWork.GetRepositoryInstance<Tbl_SectionDistribution>().Add(tbl);
            _unitOfWork.GetRepositoryInstance<Tbl_PreSectionDistribution>().Remove(k);


            return RedirectToAction("SectionConfirm");
        }
        public ActionResult SectionDetails(int id)
        {
            Tbl_PreSectionDistribution k = _unitOfWork.GetRepositoryInstance<Tbl_PreSectionDistribution>().GetAllRecordsIQueryable().Where(x => x.SectionID == id).FirstOrDefault();
            return View(k);
        }
        public ActionResult CancelSection(int id)
        {
            Tbl_PreSubjectDetails k = _unitOfWork.GetRepositoryInstance<Tbl_PreSubjectDetails>().GetAllRecordsIQueryable().Where(x => x.SubjectID == id).FirstOrDefault();
            _unitOfWork.GetRepositoryInstance<Tbl_PreSubjectDetails>().Remove(k);
            return RedirectToAction("SectionConfirm");
        }

    }
}