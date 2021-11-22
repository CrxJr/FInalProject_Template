using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject_Template.Models
{
   public  class ListOfTemperatures
    {
        public List<Temperature> All { get; set; }
        public string totalResults { get; set; }
        public string Response { get; set; }
    }
}
