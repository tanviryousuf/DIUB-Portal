using DIUB.Models;
using DIUB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DIUB.Controllers
{
    public class TeacherController : BaseController
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        /* 
         public List<SelectListItem> GetSection()
        {
            string a = Session["userID"].ToString();
            List<SelectListItem> list = new List<SelectListItem>();
            var cat = _unitOfWork.GetRepositoryInstance<Tbl_SectionDistribution>().GetAllRecords().Where(x=>x.TeacherID ==a );
            foreach (var item in cat)
            {
                list.Add(new SelectListItem { Value = item.SectionID.ToString(), Text = item.SectionName });
            }
            return list;
        }
             */
        // GET: Teacher
       
        public List<SelectListItem> GetSection()
        {
            string a = Session["userID"].ToString();
            List<SelectListItem> list = new List<SelectListItem>();
            var cat = _unitOfWork.GetRepositoryInstance<Tbl_SectionDistribution>().GetAllRecordsIQueryable().Where(x=>x.TeacherID == a);
            foreach (var item in cat)
            {
                list.Add(new SelectListItem { Value = item.SectionID.ToString(), Text = item.SectionName.ToString() +"("+item.Tbl_SubjectDetails.SubjectName+")" });
            }
            return list;
        }
       
        public ActionResult Index()
        {
            string a = Session["userID"].ToString();
            var classschedule = _unitOfWork.GetRepositoryInstance<Tbl_SectionDistribution>().GetAllRecordsIQueryable().Where(x => x.TeacherID == a);
            return View(classschedule);
        }
        public ActionResult Attandance()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Attandance(Tbl_AttandanceMid tbl)
        {

            return View();
        }
        public ActionResult Marks()
        {
            string a = Session["userID"].ToString();
            return View(_unitOfWork.GetRepositoryInstance<Tbl_MidResult>().GetAllRecordsIQueryable().Where(x => x.TeacherID == a).OrderBy(x => x.SectionID));
        }
        [HttpGet]
        public ActionResult MarkUploadMid(int resultID)
        {

            return View(_unitOfWork.GetRepositoryInstance<Tbl_MidResult>().GetAllRecordsIQueryable().Where(x=>x.ResultID== resultID).FirstOrDefault());
        }
        [HttpPost]
       
        public ActionResult MarkUploadMid(Tbl_MidResult tbl)
        {

            _unitOfWork.GetRepositoryInstance<Tbl_MidResult>().Update(tbl);
            return RedirectToAction("Marks");
        }
       
       

       
        public ActionResult Notes()
        {
            string a = Session["userID"].ToString();
            _unitOfWork.GetRepositoryInstance<Tbl_Notes>().GetAllRecordsIQueryable().Where(x => x.TeacherID == a).OrderBy(x=>x.SectionID);
            return View();
        }
        public ActionResult NotesUpload()
        {
            ViewBag.SectionList = GetSection();
            return View();
        }
        [HttpPost]

        public ActionResult NotesUpload(Tbl_Notes tbl, HttpPostedFileBase file)
        {
            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Notes/"), pic);
                file.SaveAs(path);
            } 
            tbl.Note = pic;
            string a = Session["userID"].ToString();
            tbl.TeacherID = a;
             
            _unitOfWork.GetRepositoryInstance<Tbl_Notes>().Add(tbl);
            return RedirectToAction("MarksFinal");
        }

        // GET: Teacher/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Teacher/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Teacher/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Teacher/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
         public JsonResult Get(int? page, int? limit, string sortBy, string direction, string name, string nationality, string placeOfBirth)
        {
            List<Tbl_AttandanceMid> records;
            int total;
            using (DIUBDatabaseEntities8 context = new DIUBDatabaseEntities8())
            {
                var query = context.Tbl_AttandanceMid.Select(p => new Tbl_AttandanceMid
                {
                    StudentID = p.StudentID,
                    StudentName = p.StudentName,
                    Day1 = p.Day1,
                    Day2 = p.Day2,
                    Day3 = p.Day3,
                    Day4 = p.Day4,
                    Day5 = p.Day5,
                    Day6 = p.Day6,
                    Day7 = p.Day7,
                    Day8 = p.Day8,
                    Day9 = p.Day9,
                    Day10 = p.Day10,
                    Day11 = p.Day11,
                    Day12 = p.Day12,
                    TotalAttandanceMid = p.TotalAttandanceMid
                    
                });

               

              

                total = query.Count();
                if (page.HasValue && limit.HasValue)
                {
                    int start = (page.Value - 1) * limit.Value;
                    records = query.Skip(start).Take(limit.Value).ToList();
                }
                else
                {
                    records = query.ToList();
                }
            }

            return this.Json(new { records, total }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(Tbl_AttandanceMid record)
        {
            Tbl_AttandanceMid entity;
            using (DIUBDatabaseEntities8 context = new DIUBDatabaseEntities8())
            {
                if (record.AttandanceID > 0)
                {
                    entity = context.Tbl_AttandanceMid.First(p => p.AttandanceID == record.AttandanceID);
                    entity.StudentID = record.StudentID;
                    entity.StudentName = record.StudentName;
                    entity.Day1 = record.Day1;
                    entity.Day2 = record.Day2;
                    entity.Day3 = record.Day3;
                    entity.Day4 = record.Day4;
                    entity.Day5 = record.Day5;
                    entity.Day6 = record.Day6;
                    entity.Day7 = record.Day7;
                    entity.Day8 = record.Day8;
                    entity.Day9 = record.Day9;
                    entity.Day10 = record.Day10;
                    entity.Day11 = record.Day11;
                    entity.Day12 = record.Day12;
                    entity.TotalAttandanceMid = record.TotalAttandanceMid;
                }
                
                context.SaveChanges();
            }
            return Json(new { result = true });
        }
        public List<SelectListItem> GetBooks()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var cat = _unitOfWork.GetRepositoryInstance<Tbl_Book>().GetAllRecords();
            foreach (var item in cat)
            {
                list.Add(new SelectListItem { Value = item.BookID.ToString(), Text = item.BookName + "(" + item.Tbl_Category.CategoryName + ")" });
            }
            return list;
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



        //    _unitOfWork.GetRepositoryInstance<Tbl_Request>().Add(tbl);


        //    return RedirectToAction("Index");
        //}




    }
}
