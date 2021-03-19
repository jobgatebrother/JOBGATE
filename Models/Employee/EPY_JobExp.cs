using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE.Models
{
    public class EPY_JobExp
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar(20)")]
        public string ResumeID { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string CompanyName { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateStartWork { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateEndWork { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Statuswork { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Industry { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string JobField { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Position { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string WorkingDept { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Province { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string District { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string SubDistrict { get; set; }

        [Column(TypeName = "bit")]
        public bool Oversea { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Country { get; set; }

        [Column(TypeName = "int")]
        public int Salary { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        public string Jobduty { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DateCreate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DateEdit { get; set; }
    }
}
