using DIUB.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DIUB.Models
{
    public class BookIndexViewModel
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        DIUBDatabaseEntities8 Context = new DIUBDatabaseEntities8();
        public IPagedList<Tbl_Book> ListOfProducts { get; set; }

        public BookIndexViewModel CreateModel(string search, int pageSize, int? page)
        {
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@search",search??(object)DBNull.Value)
            };
            IPagedList<Tbl_Book> data = Context.Database.SqlQuery<Tbl_Book>("GetBySearch @search", param).ToList().ToPagedList(page ?? 1, pageSize);
            return new BookIndexViewModel
            {
                ListOfProducts = data
            };
        }
    }
}