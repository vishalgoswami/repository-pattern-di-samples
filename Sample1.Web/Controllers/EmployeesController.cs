using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sample1.DbFirstManual.Data.Core.Domains;
using Sample1.DbFirstManual.Data.Core.Interfaces;
using Sample1.DbFirstManual.Data.Infrastructure.Repositories;

namespace Sample1.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _empRepo;// = new EmployeeRepository();

        //private Sample1DbContext db = new Sample1DbContext();

        public EmployeesController(IEmployeeRepository empRepo)
        {
            _empRepo = empRepo;
        }

        // GET: Employees
        public ActionResult Index()
        {
            //return View(db.Employees.ToList());
            return View(_empRepo.GetEmployees());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = _empRepo.FindById(id.Value);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _empRepo.Add(employee);
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var emp = _empRepo.FindById(id.Value);
            _empRepo.Edit(emp);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _empRepo.Edit(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var emp = _empRepo.FindById(id.Value);
            _empRepo.Edit(emp);
            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var emp = _empRepo.FindById(id);
            _empRepo.Remove(id);
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
