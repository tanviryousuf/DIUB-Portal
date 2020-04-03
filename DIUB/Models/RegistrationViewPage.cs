using DIUB.Repository;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DIUB.Models
{
    public class RegistrationViewPage
    {
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();
        DIUBDatabaseEntities8 Context = new DIUBDatabaseEntities8();
        public IPagedList<Tbl_Registration> ListOfProducts { get; set; }

        public RegistrationViewPage CreateModel(string id,int sid, int pageSize, int? page)
        {
           
            IPagedList<Tbl_Registration> data = _unitOfWork.GetRepositoryInstance<Tbl_Registration>().GetAllRecordsIQueryable().Where(x=>x.SemesterID==sid && x.StudentID==id).ToList().ToPagedList(page ?? 1, pageSize);
            return new RegistrationViewPage
            {
                ListOfProducts = data
            };
        }
    }
}