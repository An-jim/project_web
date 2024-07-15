using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using project_web.Models.ViewModel;
using System.Data.Entity;

namespace project_web.Controllers
{
    public class financialController : Controller
    {
        private Models.masterEntities db = new Models.masterEntities();

        // GET: financial
        public ActionResult financial_report(int id)
        {
            financial_viewmodel fnviewmodel = new financial_viewmodel();

           

                fnviewmodel.date = (from s in db.fin_rpt group s by new { s.year } into mygroup select mygroup.FirstOrDefault()).OrderByDescending(o => o.year).ToList();

                fnviewmodel.context_ch = (from s in db.fin_rpt where s.year == id && s.lang == "ch" select s).ToList();

                fnviewmodel.context_en = (from s in db.fin_rpt where s.year == id && s.lang == "en" select s).ToList();

                ViewBag.max = (from s in db.fin_rpt select s.year).Max();

                fnviewmodel.id = id;



            return View(fnviewmodel);
        }
    }
}