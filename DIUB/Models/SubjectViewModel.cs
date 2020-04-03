using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace DIUB.Models
{
    public  class SubjectViewModel
    {
        IEnumerable<Tbl_Teacher1> Teacher { get; set; }
        IEnumerable<Tbl_SectionDistribution> Section { get; set; }
        IEnumerable<Tbl_Notes> Notess { get; set; }
    }
}