using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment2_DatDang_U3091855.Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Assessment> Assessments { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Teaching> Teachings { get; set; }
        public DbSet<Enrolment> Enrolments { get; set; }
    }

}