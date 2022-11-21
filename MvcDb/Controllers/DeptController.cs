using Microsoft.AspNetCore.Mvc;
using MvcDb.Models;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace MvcDb.Controllers
{
    public class DeptController : Controller
    {
        IDept repo;
        public DeptController(IDept repo)
        {
            this.repo = repo;
        }
        public IActionResult List()
        {
            var data = repo.GetDepts();
            return View(data);
        }
        public IActionResult Display(int id)
        {
            var data = repo.FindDept(id);
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Dept dept)
        {
            if(ModelState.IsValid)
            {
                repo.AddDept(dept);
                return RedirectToAction("List");
            }
            return View(dept);
        }
        public JsonResult DeptCheck(int Id)
        {
            db1064Context db = new db1064Context();
            bool yesno = db.Depts.Any(d => d.Id == Id);
            return Json(!yesno);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var data = repo.FindDept(Id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Dept dept)
        {
            if(ModelState.IsValid)
            {
                repo.EditDept(dept);
                return RedirectToAction("List");
            }
            return View(dept);
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var data = repo.FindDept(Id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Delete(Dept dept)
        {
            repo.DeleteDept(dept.Id);
            return RedirectToAction("List");
        }
    }
}
