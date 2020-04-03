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
    
    public partial class Tbl_PreTeacher
    {
        public int ID { get; set; }
        public string TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<int> DepartmentID { get; set; }
        public string PermanentAddress { get; set; }
        public string PresentAddress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Sex { get; set; }
        public string Nationality { get; set; }
        public string Religion { get; set; }
        public string MaritalStatus { get; set; }
        public string BloodGroup { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public string Picture { get; set; }
        public string DocumentsGiven { get; set; }
        public Nullable<int> SalaryCategoryID { get; set; }
        public Nullable<System.DateTime> JoiningDate { get; set; }
        public string Status { get; set; }
    
        public virtual Tbl_Department Tbl_Department { get; set; }
        public virtual Tbl_SalaryCategory Tbl_SalaryCategory { get; set; }
    }
}
