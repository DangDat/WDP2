using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment2_DatDang_U3091855.Models
{
    [Table("Forums")]
    public class Forum
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PostID { get; set; }
        public string Posttopic { get; set; }
        public string Postname { get; set; }
        public string Postcomment { get; set; }
        public DateTime PostDate { get; set; }
    }
    //public class ForumDBContext : DbContext
    //{
    //    public ForumDBContext()
    //        : base("DefaultConnection")
    //    {
    //    }

    //    public DbSet<Forum> Forums { get; set; }
    //}
}