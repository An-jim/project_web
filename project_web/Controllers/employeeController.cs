using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using project_web.Models;

namespace project_web.Controllers
{
    public class employeeController : Controller
    {
        private Models.masterEntities db = new Models.masterEntities();
        // GET: employee
        
         /*public ActionResult Index()
        {
            ViewBag.name = User.Identity.Name;
            return View();
        }*/

        [HttpPost]
        [AllowAnonymous]
        public ActionResult login(string id, string password)
        {
            using (db)
            {
                var ids = (from s in db.Employees select s.FirstName).ToArray();
                var pass = (from s in db.Employees select s.password).ToArray();

                for (int i = 0; i < ids.Length; i++)
                {
                    if (id == ids[i] && password == pass[i])
                    {
                        ViewBag.id = id;
                        ViewBag.password = password;
                        FormsAuthentication.RedirectFromLoginPage(id, false);
                        return RedirectToAction("index", "employee");
                    }
                    ViewBag.error = "帳密密碼錯誤";
                }
            }

            //ViewBag.id = id;

            //ViewBag.password = password;

            return View();
        }

        [AllowAnonymous]
        public ActionResult login()
        {
            return View();
        }

        public ActionResult logout()

        {
            FormsAuthentication.SignOut();
            return RedirectToAction("log");

        }

        public ActionResult index()
        {

            var em = db.Employees.ToList();
            ViewBag.name = User.Identity.Name;
            return View(em); }

        // GET: employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: employee/Create
        public ActionResult Create()
        {
            return View(new Employees());
        }

        // POST: employee/Create
        [HttpPost]
        public ActionResult Create(Employees emp)
        {
            try
            {
                // TODO: Add insert logic here

                var add= db.Employees.Add(emp);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: employee/Edit/5
        public ActionResult Edit(int id)
        {

            var emo_up = db.Employees.Where(m => m.EmployeeID == id).FirstOrDefault();
            return View(emo_up);
        }

        // POST: employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Employees emp)
        {
            try
            {
                // TODO: Add update logic here
                var admin_data = db.Employees.Where(m => m.EmployeeID == emp.EmployeeID).FirstOrDefault();



                admin_data.EmployeeID = emp.EmployeeID;
                admin_data.password = emp.password;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: employee/Delete/5
        public ActionResult Delete(int id)
        {
            var emp_d = db.Employees.Where(m => m.EmployeeID == id).FirstOrDefault();
            return View(emp_d);
        }

        // POST: employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Employees emp)
        {
            try
            {
                // TODO: Add delete logic here
                var emp_d = db.Employees.Where(m => m.EmployeeID == id).FirstOrDefault();
                db.Employees.Remove(emp_d);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
