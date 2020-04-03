using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DIUB.Models
{
    public class RegistrationItem
    {
        public Tbl_SectionDistribution Section { get; set; }
        public int CreditTotal { get; set; }
        public decimal TotalCost { get; set; }
    }
}