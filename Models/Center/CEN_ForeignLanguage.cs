using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE.Models
{
    public class CEN_ForeignLanguage
    {
        public int ID { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string LanguagelevelID { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string LanguagelevelTH { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string LanguagelevelEN { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string ForeignLanguageID { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string ForeignLanguageTH { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string ForeignLanguageEN { get; set; }

    }
}
