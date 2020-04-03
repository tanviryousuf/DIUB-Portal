using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DIUB.Models
{
    public class Item
    {
        public Tbl_Book Book { get; set; }
        public int Quantity { get; set; }
    }
}