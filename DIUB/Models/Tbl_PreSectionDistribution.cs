//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DIUB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_PreSectionDistribution
    {
        public int SectionID { get; set; }
        public string SectionName { get; set; }
        public Nullable<int> Capacity { get; set; }
        public Nullable<int> SubjectID { get; set; }
        public Nullable<System.TimeSpan> ClassStart { get; set; }
        public Nullable<System.TimeSpan> ClassEnd { get; set; }
        public string Day1 { get; set; }
        public string Day2 { get; set; }
        public Nullable<int> SemesterID { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public Nullable<System.TimeSpan> ClassStart2 { get; set; }
        public Nullable<System.TimeSpan> ClassEnd2 { get; set; }
        public Nullable<int> Available { get; set; }
        public Nullable<int> Credit { get; set; }
        public Nullable<bool> IsConfirmed { get; set; }
        public string Status { get; set; }
        public string TeacherID { get; set; }
        public string RoomNo { get; set; }
    
        public virtual Tbl_Department Tbl_Department { get; set; }
        public virtual Tbl_Semester Tbl_Semester { get; set; }
        public virtual Tbl_SubjectDetails Tbl_SubjectDetails { get; set; }
        public virtual Tbl_Teacher1 Tbl_Teacher1 { get; set; }
    }
}
