using Microsoft.AspNetCore.Mvc;
using MvcDb.Models;
using MvcDb.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace MvcDb.Controllers
{
    public class EmpController : Controller
    {
        db1064Context db = new db1064Context();
        public IActionResult List()
        {
            var data = db.Emps.Include("Dept").ToList();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Dept = new SelectList(db.Depts, "Id", "Name"); //selectlist(from where, what field, what to display)
            return View();
        }
        [HttpPost]
        public IActionResult Create(Emp emp)
        {
            if (ModelState.IsValid)
            {
                db.Emps.Add(emp);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            ViewBag.Dept = new SelectList(db.Depts, "Id", "Name");
            return View(emp);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = db.Emps.Find(id);
            ViewBag.Deptid = new SelectList(db.Depts, "Id", "Name");
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Emp emp)
        {
            if(ModelState.IsValid)
            {
                var oemp = db.Emps.Find(emp.Id);
                oemp.Name = emp.Name;
                oemp.Salary = emp.Salary;
                oemp.Dob = emp.Dob;
                oemp.Email = emp.Email;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            ViewBag.Deptid = new SelectList(db.Depts, "Id", "Name");
            return View(emp);
        }
        public IActionResult Display(int id)
        {
            var data = (from e in db.Emps.Include("Dept") where e.Id == id select e).FirstOrDefault();
            return View(data);
        }
    }
}
