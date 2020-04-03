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
    
    public partial class Tbl_AttandanceMid
    {
        public int AttandanceID { get; set; }
        public string TeacherID { get; set; }
        public string TeacherName { get; set; }
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public Nullable<int> SectionID { get; set; }
        public string SectionName { get; set; }
        public Nullable<int> SubjectID { get; set; }
        public Nullable<bool> Day1 { get; set; }
        public Nullable<bool> Day2 { get; set; }
        public Nullable<bool> Day3 { get; set; }
        public Nullable<bool> Day4 { get; set; }
        public Nullable<bool> Day5 { get; set; }
        public Nullable<bool> Day6 { get; set; }
        public Nullable<bool> Day7 { get; set; }
        public Nullable<bool> Day8 { get; set; }
        public Nullable<bool> Day9 { get; set; }
        public Nullable<bool> Day10 { get; set; }
        public Nullable<bool> Day11 { get; set; }
        public Nullable<bool> Day12 { get; set; }
        public Nullable<int> TotalAttandanceMid { get; set; }
        public Nullable<int> SemesterID { get; set; }
    
        public virtual Tbl_SectionDistribution Tbl_SectionDistribution { get; set; }
        public virtual Tbl_Semester Tbl_Semester { get; set; }
        public virtual Tbl_Student Tbl_Student { get; set; }
        public virtual Tbl_Teacher1 Tbl_Teacher1 { get; set; }
    }
}
