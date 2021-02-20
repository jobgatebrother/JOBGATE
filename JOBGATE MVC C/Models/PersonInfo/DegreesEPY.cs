using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE_MVC_C.Models.PersonInfo
{
    public class DegreesEPY
    {
        [Key]
        public int Id { get; set; }
        public string DegreeName { get; set; }
    }
}
