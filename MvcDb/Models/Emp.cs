using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MvcDb.Models
{
    public partial class Emp
    {
        [Display(Name="Employee Id")]
        public int Id { get; set; }

        [Display(Name="Employee Name")]
        [Required(ErrorMessage = "Name cannot be empty")]
        public string Name { get; set; }

        [Display(Name="Salary")]
        [Range(10000,90000, ErrorMessage ="Salary not in range")]
        public int? Salary { get; set; }

        [Display(Name="Department ID")] //add dropdown as checking isn't available
        public int? Deptid { get; set; }

        [Display(Name="Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name="Date of Birth")]
        public DateTime? Dob { get; set; }

        public virtual Dept Dept { get; set; }
    }
}
