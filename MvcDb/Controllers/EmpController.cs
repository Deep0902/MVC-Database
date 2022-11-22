using Microsoft.AspNetCore.Mvc;
using MvcDb.Models;
using MvcDb.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
    }
}
