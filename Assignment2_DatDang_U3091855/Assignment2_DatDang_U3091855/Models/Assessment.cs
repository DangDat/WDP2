using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Assignment2_DatDang_U3091855.Models
{
    [Table("Assessments")]
    public class Assessment
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AssessmentID { get; set; }
        public string AssessmentName { get; set; }
        public string AssessmentLink { get; set; }
        public float AssessmentGrade { get; set; }
        public DateTime AssessmentDate { get; set; }
    }
}