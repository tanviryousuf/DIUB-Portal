using DIUB.Models;
using DIUB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DIUB.Controllers
{
    public class LibraryController : BaseController
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        public ActionResult Index(string search, int? page)
        {
            BookIndexViewModel model = new BookIndexViewModel();

            return View(model.CreateModel(search, 20, page));
        }
        //public ActionResult Request()
        //{
        //    var show = _unitOfWork.GetRepositoryInstance<Tbl_Request>().GetAllRecords();
        //    return View(show);
        //}
        //public ActionResult BookNew()
        //{
        //    var show = _unitOfWork.GetRepositoryInstance<Tbl_Book>().GetAllRecords().OrderBy(x=>x.BuyingDate).Reverse();
        //    return View(show);
        //}
        //public ActionResult BookOld()
        //{
        //    var show = _unitOfWork.GetRepositoryInstance<Tbl_Book>().GetAllRecords().OrderBy(x => x.BuyingDate);
        //    return View(show);
        //}
        public List<SelectListItem> GetCategory()
        {
            List<SelectListItem> list = new List<SelectListItem>();
            var cat = _unitOfWork.GetRepositoryInstance<Tbl_Category>().GetAllRecords();
            foreach (var item in cat)
            {
                list.Add(new SelectListItem { Value = item.CategoryID.ToString(), Text = item.CategoryName });
            }
            return list;
        }
        public ActionResult BookAdd()
        {
            ViewBag.CategoryList = GetCategory();
            return View();
        }
        [HttpPost]
        public ActionResult BookAdd(Tbl_Book tbl,HttpPostedFileBase file)
        {

            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Books/"), pic);
                file.SaveAs(path);
            }
            tbl.BookImage = pic;
            _unitOfWork.GetRepositoryInstance<Tbl_Book>().Add(tbl);
            return RedirectToAction("Index");
        }
        public ActionResult CategoryAdd()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Tbl_Category tbl)
        {

            
            _unitOfWork.GetRepositoryInstance<Tbl_Category>().Add(tbl);
            return RedirectToAction("Index");
        }
        //public ActionResult RequestOfBooks()
        //{


        //  var m =   _unitOfWork.GetRepositoryInstance<Tbl_Request>().GetAllRecords();
        //    return View(m);
        //}
        //public ActionResult ConfirmBorrowBook(Tbl_Borrow tbl,int id)
        //{
        //    var kal = _unitOfWork.GetRepositoryInstance<Tbl_Request>().GetAllRecordsIQueryable().Where(x => x.RequestID == id).FirstOrDefault();
        //    var kk = _unitOfWork.GetRepositoryInstance<Tbl_Book>().GetAllRecordsIQueryable().Where(x => x.BookID ==kal.BookID).FirstOrDefault();
        //    tbl.StudentID = kal.StudentID;
        //    tbl.BookID = kal.BookID;
        //    tbl.BorrowDate = kal.BorrowDate;
        //    tbl.IsSubmitted = false;
        //    kk.Quantity = kk.Quantity - 1;
        //    _unitOfWork.GetRepositoryInstance<Tbl_Borrow>().Add(tbl);
        //    _unitOfWork.GetRepositoryInstance<Tbl_Book>().Update(kk);
        //    _unitOfWork.GetRepositoryInstance<Tbl_Request>().RemovebyWhereClause(x => x.RequestID == id);
        //    return RedirectToAction("Index");
        //}
        public ActionResult Borrower()
        {
            return View(_unitOfWork.GetRepositoryInstance<Tbl_Borrow>().GetAllRecords());
        }
            public ActionResult ReturnBook( int id)
        {
            
           var u = _unitOfWork.GetRepositoryInstance<Tbl_Borrow>().GetAllRecords().Where(x => x.BorrowID == id && x.IsSubmitted != true);
            return View(u);
        }
        [HttpPost]
        public ActionResult ReturnBook(Tbl_Borrow tbl, int id)
        {
            var kal = _unitOfWork.GetRepositoryInstance<Tbl_Borrow>().GetAllRecordsIQueryable().Where(x => x.BorrowID == id).FirstOrDefault();

            var kk = _unitOfWork.GetRepositoryInstance<Tbl_Book>().GetAllRecordsIQueryable().Where(x => x.BookID == kal.BookID).FirstOrDefault();

            tbl.Due = tbl.Penalty - tbl.PenaltyPaid;
           
            tbl.IsSubmitted = false;
            kk.Quantity = kk.Quantity + 1;
            _unitOfWork.GetRepositoryInstance<Tbl_Borrow>().Update(tbl);
            _unitOfWork.GetRepositoryInstance<Tbl_Book>().Update(kk);
            
            return RedirectToAction("Index");
        }

    }
}