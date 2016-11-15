using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment2_DatDang_U3091855.Models
{
    [Table("Teachings")]
    public class Teaching
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int FileID { get; set; }
        public string Filename { get; set; }
        public string Label { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}