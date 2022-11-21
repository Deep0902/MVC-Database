using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable
//model
namespace MvcDb.Models
{
    public partial class Dept
    {
        public Dept()
        {
            Emps = new HashSet<Emp>();
        }
        [Remote("DeptCheck","Dept",ErrorMessage ="Duplicate Dept Id")]
        [Display(Name="Dept ID")]
        [Required(ErrorMessage ="Id required")]
        public int Id { get; set; }

        [Display(Name = "Department Name")]
        [Required(ErrorMessage ="Name cannot be blank")]
        public string Name { get; set; }

        [Display(Name = "City")]
        [StringLength(25,MinimumLength =3,ErrorMessage ="Min 3 chars required")]
        public string Loc { get; set; }

        public virtual ICollection<Emp> Emps { get; set; }
    }
}
