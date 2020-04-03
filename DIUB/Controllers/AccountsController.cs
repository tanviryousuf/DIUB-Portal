using DIUB.Models;
using DIUB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DIUB.Controllers
{
    public class AccountsController : Controller
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        // GET: Accounts
        public ActionResult Login()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult Login(string User,string Pass)
        {
            var ID = _unitOfWork.GetRepositoryInstance<Tbl_Accounts1>().GetAllRecords().Where(x => x.UserID == User && x.Password == Pass).FirstOrDefault();

            if (ID != null)
            {
                if(ID.Type == "Teacher")
                {
                    Session["userID"] = User;
                    return RedirectToAction("Index", "Teacher");
                }
                else if(ID.Type == "Student")
                {
                    Session["userID"] = User;
                    return RedirectToAction("ShowclassSchedule", "Student");
                }
                else if(ID.Type == "Employee")
                {
                    Session["userID"] = User;
                    return RedirectToAction("Index", "AdministrationOfficial");
                }
                else if (ID.Type == "Librarian")
                {
                    Session["userID"] = User;
                    return RedirectToAction("Index", "Library");
                }
                else if(ID.Type == "Director")
                {
                    Session["userID"] = User;
                    return RedirectToAction("Index", "Director");
                }

                else if(ID.Type == "Manager")
                {
                    Session["userID"] = User;
                    return RedirectToAction("Index", "Manager");
                }
                else
                {
                    ViewBag.Message = "Incorrect UserID or Password.";
                    return View("Login");
                }
               
                
              

                
            }
            else
            {
                ViewBag.Message = "Incorrect UserID or Password.";
                return RedirectToAction("Login");
            }
            
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            
            return RedirectToAction("Login", "Accounts");
        }
    }
}