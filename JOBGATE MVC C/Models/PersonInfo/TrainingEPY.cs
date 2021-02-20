using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE_MVC_C.Models.PersonInfo
{
    public class TrainingEPY
    {
        [Key]
        public int Id { get; set; }
        public string TrainingName { get; set; }
        public string Issued_by { get; set; }
        public int StartYear { get; set; }
        public int StartMonth { get; set;  }
        public int EndYear { get; set; }
        public int EndMonth { get; set; }

    }
}
