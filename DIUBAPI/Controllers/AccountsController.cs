using DIUBAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DIUBAPI.Controllers
{
    [RoutePrefix("api/Accounts")]
    public class AccountsController : ApiController
    {
        DIUBDatabaseEntities context = new DIUBDatabaseEntities();
        [Route("")]
        public IHttpActionResult Get()
        {
            var list = context.Tbl_Accounts1.ToList();
            List<Tbl_Accounts1> categories = new List<Tbl_Accounts1>();
            foreach (var item in list)
            {
                Tbl_Accounts1 cat = new Tbl_Accounts1();
                cat.AccountID = item.AccountID;
                cat.UserID = item.UserID;
                cat.Password = item.Password;
                cat.Type = item.Type;
                cat.Status = item.Status;
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts", Method = "GET", Rel = "Self" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Posts/" + cat.UserID, Method = "GET", Rel = "Specific Resource" });
               
               
                categories.Add(cat);
            }
            return Ok(categories);
        }
        [Route("{id}", Name = "GetPostById")]
        public IHttpActionResult Get(string id)
        {
            var item = context.Tbl_Accounts1.Where(p => p.UserID == id).FirstOrDefault();
            if (item == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            else
            {
                Tbl_Accounts1 cat = new Tbl_Accounts1();
                cat.AccountID = item.AccountID;
                cat.UserID = item.UserID;
                cat.Password = item.Password;
                cat.Type = item.Type;
                cat.Status = item.Status;
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Accounts", Method = "GET", Rel = "All Resources" });
                cat.links.Add(new Links() { HRef = "http://localhost:57254/api/Accounts/" + cat.UserID, Method = "GET", Rel = "Self" });
                
                return Ok(cat);
            }

        }
        
    }
}
