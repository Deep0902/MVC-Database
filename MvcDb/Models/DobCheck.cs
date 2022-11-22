using System;
using System.ComponentModel.DataAnnotations;

namespace MvcDb.Models
{
	public class DobCheck : ValidationAttribute
	{
		public override bool IsValid(object value)
		{
			DateTime birthdate = Convert.ToDateTime(value);
			int year = birthdate.Year;
			int todayyear = DateTime.Now.Year;
			if(todayyear - year >=25)
				return true;
			else
				return false;
		}
	}
}
