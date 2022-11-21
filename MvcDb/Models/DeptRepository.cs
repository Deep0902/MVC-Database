using MvcDb.Models;
using System.Collections.Generic;
using System;
using System.Linq;
//repo class with methods
public class DeptRepository : IDept
{
    db1064Context context = new db1064Context();
    public void AddDept(Dept dept)
    {
        context.Depts.Add(dept);
        context.SaveChanges();
    }

    public void DeleteDept(int id)
    {
        Dept dept = context.Depts.Find(id);
        context.Depts.Remove(dept);
        context.SaveChanges();
    }

    public void EditDept(Dept dept)
    {
        Dept odept = context.Depts.Find(dept.Id);
        odept.Name = dept.Name;
        odept.Loc = dept.Loc;
        context.SaveChanges();
    }

    public Dept FindDept(int id)
    {
        //var data = (from d in context.Depts where d.Id = id select d).FirstoOrddefault;
        var data = context.Depts.Find(id);
        return data;
    }

    public List<Dept> GetDepts()
    {
        return context.Depts.ToList();
    }

}