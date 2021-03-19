using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE.Models
{
    public class EPY_Education
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string ResumeID { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Degree { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string SchoolName { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string StudyCatagory { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string MajorSubject { get; set; }

        [Column(TypeName = "int")]
        public int GraduatationYear { get; set; }

        [Column(TypeName = "decimal(4,2)")]
        public decimal GPA { get; set; }

    }
}
