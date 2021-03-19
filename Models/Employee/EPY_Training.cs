using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE.Models
{
    public class EPY_Training
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string SkillID { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string TrainingName { get; set; }


        [Column(TypeName = "varchar(max)")]
        public string Issued_by { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime StartTraining { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime EndTraining { get; set; }

    }
}
