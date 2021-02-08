using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JOBGATE_MVC_C.Models
{
    public class ViewModel
    {
        public Register_EPYModel register_EPYModel { get; set; }
        public Register_CPNModel register_CPNModel { get; set; }


    }
    public class EPYViewModel
    {
        public Register_EPYModel register_EPYModel { get; set; }
        public List<Register_EPYModel> EPY { get; set; }
    }
    public class ECPNViewModel
    {
        public Register_CPNModel register_CPNModel { get; set; }
        public List<Register_CPNModel> CPN { get; set; }
    }

}
