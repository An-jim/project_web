using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace project_web.Models.ViewModel
{
    public class financial_viewmodel
    {
        public List<fin_rpt> date { get; set; }

        public List<fin_rpt> context_ch { get; set; }

        public List<fin_rpt> context_en { get; set; }

        public int id { get; set; }
        //financial
    }
}