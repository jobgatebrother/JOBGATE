using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE.Models
{
    public class EPY_RequiredJob
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string JobField1 { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string JobField2 { get; set; }

        [Column(TypeName = "bit")]
        public bool FullTime { get; set; }

        [Column(TypeName = "bit")]
        public bool PartTime { get; set; }

        [Column(TypeName = "bit")]
        public bool Freelance { get; set; }

        [Column(TypeName = "bit")]
        public bool Intern { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string WorkLocation { get; set; }

        [Column(TypeName = "int")]
        public int ExpectedSalary { get; set; }

    }
}
