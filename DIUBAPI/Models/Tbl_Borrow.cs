//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DIUBAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Borrow
    {
        public int BorrowID { get; set; }
        public Nullable<System.DateTime> BorrowDate { get; set; }
        public Nullable<int> BookID { get; set; }
        public string StudentID { get; set; }
        public string TeacherID { get; set; }
        public Nullable<System.DateTime> ReturnBookDate { get; set; }
        public Nullable<decimal> Penalty { get; set; }
        public Nullable<decimal> PenaltyPaid { get; set; }
        public Nullable<decimal> Due { get; set; }
        public Nullable<bool> IsSubmitted { get; set; }
    
        public virtual Tbl_Book Tbl_Book { get; set; }
        public virtual Tbl_Student Tbl_Student { get; set; }
        public virtual Tbl_Teacher1 Tbl_Teacher1 { get; set; }
    }
}
