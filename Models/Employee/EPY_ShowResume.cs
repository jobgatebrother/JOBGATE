using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE.Models
{
    public partial class EPY_ShowResume
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Employee { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Education { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string RequiredJob { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string JobExp { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string SkillTraning { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Date_create { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Date_update { get; set; }

        [Column(TypeName = "bit")]
        public bool Status_open { get; set; }

    }
}
