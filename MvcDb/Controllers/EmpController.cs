using Microsoft.AspNetCore.Mvc;
using MvcDb.Models;
using MvcDb.Controllers;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using MvcDb.ViewModel;

namespace MvcDb.Controllers
{
    public class EmpController : Controller
    {
        db1064Context db = new db1064Context();
        public IActionResult List()
        {
            List<Emp> data;
            try
            {
                data = db.Emps.Include("Dept").ToList();
            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("Error");
            }
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

        public IActionResult ShowBonus()
        {
            List<Emp> emps = db.Emps.Include("Dept").ToList(); //we've to include dept so we get dept details
            List<EmpDeptVm> empDeptVms = new List<EmpDeptVm>();
            foreach(var data in emps)
            {
                EmpDeptVm vm = new EmpDeptVm();
                vm.Id = data.Id;
                vm.Name = data.Name;
                vm.Salary = data.Salary;
                vm.DeptName = data.Dept.Name;
                vm.Location = data.Dept.Loc;
                if(vm.Salary >= 70000)
                {
                    vm.Bonus = 7000;
                    vm.Color = "yellow";
                }
                else if(vm.Salary>=40000)
                {
                    vm.Bonus = 4000;
                    vm.Color = "cyan";
                }
                else
                {
                    vm.Bonus = 2000;
                    vm.Color = "lime";
                }
                empDeptVms.Add(vm);
            }
            return View(empDeptVms);
        }
    }
}
