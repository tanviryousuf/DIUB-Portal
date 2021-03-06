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
    
    public partial class Tbl_LabResult
    {
        public int LabID { get; set; }
        public Nullable<double> Lab1 { get; set; }
        public Nullable<double> Lab2 { get; set; }
        public Nullable<double> Lab3 { get; set; }
        public Nullable<double> Lab4 { get; set; }
        public Nullable<double> LabMid { get; set; }
        public Nullable<double> Lab5 { get; set; }
        public Nullable<double> Lab6 { get; set; }
        public Nullable<double> Lab7 { get; set; }
        public Nullable<double> Lab8 { get; set; }
        public Nullable<double> LabFinal { get; set; }
        public string StudentID { get; set; }
        public string TeacherID { get; set; }
        public string StudentName { get; set; }
        public string TeacherName { get; set; }
        public Nullable<int> SectionID { get; set; }
        public Nullable<int> SemesterID { get; set; }
    
        public virtual Tbl_SectionDistribution Tbl_SectionDistribution { get; set; }
        public virtual Tbl_Semester Tbl_Semester { get; set; }
        public virtual Tbl_Student Tbl_Student { get; set; }
        public virtual Tbl_Teacher1 Tbl_Teacher1 { get; set; }
    }
}
