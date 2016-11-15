using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment2_DatDang_U3091855.Models
{
    [Table("Enrolments")]
    public class Enrolment
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int EnrolmentID { get; set; }
        public string StudentName { get; set; }
        public DateTime EnrolmentDate { get; set; }
        public int TutorialID { get; set; }
    }

    //public class EnrolmentDBContext : DbContext
    //{
    //    public EnrolmentDBContext()
    //        : base("DefaultConnection")
    //    {
    //    }

    //    public DbSet<Enrolment> Enrolments { get; set; }
    //}

}